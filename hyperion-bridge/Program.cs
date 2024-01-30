
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

        Console.WriteLine("[hyperion-bridge] Standard input not detected; reading input...");

        while (true)
        {
            var input = Console.ReadLine();

            // End of standard input; exit program.
            if (input == null)
                return;

            // TODO: Handle other commands.
            var isPlayerPosition = input.StartsWith("Player Position: ");

            if (!isPlayerPosition)
                continue;

            var positionString = input.Split("Player Position: ")[1];
            var parsedOk = int.TryParse(positionString, out int position);

            if (!parsedOk)
                continue;

            // TODO: Use real level.
            await RenderGameplay(socket, 1, position);
        }
    }

    private static async Task<Socket> Connect(string ipAddress, int port)
    {
        var ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
        var client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        await client.ConnectAsync(ipEndPoint);
        return client;
    }

    private static async Task RenderGameplay(Socket socket, int level, int position)
    {
        var ledIndicies = GetLedIndiciesForPlayer(level, position);

        var sb = new StringBuilder();

        for (var i = 0; i < LED_COUNT; i++)
        {
            if (i != 0)
            {
                sb.Append(",");
            }

            if (i >= MAX_LED_INDEX)
            {
                // Unused LEDs.
                sb.Append("0,0,0");
            }
            else if (ledIndicies.Contains(i))
            {
                // Player occupied level segment
                // TODO: Does ship change color like the level does?
                sb.Append("192,192,0"); // Yellow
            }
            else
            {
                // Unoccupied level segment
                // TODO: Set correct background color based on level.
                sb.Append("0,0,128"); // Blue
            }
        }

        var colorJson = sb.ToString();

        var json = $$"""
            {"command": "color", "color": [{{colorJson}}], "priority": 50, "origin": "{{HYPERION_ORIGIN}}"}
            """ + "\r\n";

        var messageBytes = Encoding.ASCII.GetBytes(json);
        await socket.SendAsync(messageBytes, SocketFlags.None);
    }

    private static List<int> GetLedIndiciesForPlayer(int level, int position)
    {
        var levelMap = LevelMaps.Mapping[level];
        var positionMap = levelMap[position];
        return positionMap;
    }

    public static async Task RunChaserDemo(Socket socket)
    {
        // Clear to blue; colors use G,R,B format.
        var json1 = $$"""
            {"command": "color", "color": [0,0,255], "priority": 50, "origin": "{{HYPERION_ORIGIN}}"}
            """ + "\r\n";
        var messageBytes1 = Encoding.ASCII.GetBytes(json1);
        await socket.SendAsync(messageBytes1, SocketFlags.None);

        var location = 0;
        var incrementBy = 1;
        var range = 3;

        while (true)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < 64; i++)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }

                if (i >= 56)
                {
                    // Unused LEDs.
                    sb.Append("0,0,0");
                }
                else if (location >= i - range && location <= i + range)
                {
                    // Yellow chaser dots
                    sb.Append("192,192,0");
                }
                else
                {
                    // Blue background
                    sb.Append("0,0,128");
                }
            }

            var colorJson = sb.ToString();
            var json2 = $$"""
                {"command": "color", "color": [{{colorJson}}], "priority": 50, "origin": "{{HYPERION_ORIGIN}}"}
                """ + "\r\n";
            var messageBytes2 = Encoding.ASCII.GetBytes(json2);
            await socket.SendAsync(messageBytes2, SocketFlags.None);

            location += incrementBy;

            if (location >= 56 || location <= 0)
                incrementBy = incrementBy * -1;

            Thread.Sleep(25);
        }
    }
}
