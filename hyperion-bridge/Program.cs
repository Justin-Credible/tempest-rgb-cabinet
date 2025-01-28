
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    const string HYPERION_IP_ADDRESS = "127.0.0.1";
    const int HYPERION_JSON_PORT = 19444;
    const string HYPERION_ORIGIN = "tempest rgb";
    const int LED_COUNT = 64;
    const int MAX_LED_INDEX = 56;

    public static async Task Main()
    {
        Console.WriteLine($"[hyperion-bridge] Connecting to Hyperion JSON socket '{HYPERION_IP_ADDRESS}:{HYPERION_JSON_PORT}'...");
        using var socket = await Connect(HYPERION_IP_ADDRESS, HYPERION_JSON_PORT);

        if (!Console.IsInputRedirected)
        {
            Console.WriteLine("[hyperion-bridge] Standard input not detected; running chaser demo...");
            await RunChaserDemo(socket);
            return;
        }

        Console.WriteLine("[hyperion-bridge] Standard input detected; reading input...");

        var renderer = new TempestRenderer(LED_COUNT, MAX_LED_INDEX);
        renderer.OnEmitColors += async (colors) => await Render(socket, colors);
        renderer.OnEmitEffect += async (effectName) => await SetEffect(socket, effectName);

        while (true)
        {
            var input = Console.ReadLine();

            // End of standard input; exit program.
            if (input == null)
                return;

            var message = ParseMessage(input);

            if (message == null)
                continue;

            renderer.HandleUpdates(message.Value);
        }
    }

    private static async Task<Socket> Connect(string ipAddress, int port)
    {
        var ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
        var client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        await client.ConnectAsync(ipEndPoint);
        return client;
    }

    public static async Task RunChaserDemo(Socket socket)
    {
        var renderer = new ChaserDemoRenderer(LED_COUNT);

        while (true)
        {
            var colors = renderer.Render();
            await Render(socket, colors);
            Thread.Sleep(100);
        }
    }

    private static Message? ParseMessage(string input)
    {
        var parts = input.Split(':');

        if (parts.Length != 2)
            return null;

        return new Message { Command = parts[0], Argument = parts[1] };
    }

    private static async Task Render(Socket socket, List<Color> colors)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < LED_COUNT; i++)
        {
            var color = i >= colors.Count
                ? Color.Black
                : colors[i];

            if (i != 0)
                sb.Append(",");

            // Unused LEDs
            if (i >= MAX_LED_INDEX)
                color = Color.Black;

            // JSON format expects colors in G,R,B format.
            sb.Append(color.ToGrbValuesString());
        }

        var colorJson = sb.ToString();

        var json = $$"""
            {"command": "color", "color": [{{colorJson}}], "priority": 50, "origin": "{{HYPERION_ORIGIN}}"}
            """ + "\r\n";

        var messageBytes = Encoding.ASCII.GetBytes(json);
        await socket.SendAsync(messageBytes, SocketFlags.None);
    }

    private static async Task SetEffect(Socket socket, string effectName)
    {
        // Examples:
        // { "command": "effect", "effect": { "name": "Rainbow swirl fast" }, "priority": 50, "origin": "netcattest" }
        // { "command": "effect", "effect": { "name": "Strobe red" }, "duration": 1000, "priority": 50, "origin": "netcattest" }

        var json = $$"""
            {"command": "effect", "effect": { "name": "{{effectName}}" }, "priority": 50, "origin": "{{HYPERION_ORIGIN}}"}
            """ + "\r\n";

        var messageBytes = Encoding.ASCII.GetBytes(json);
        await socket.SendAsync(messageBytes, SocketFlags.None);
    }
}
