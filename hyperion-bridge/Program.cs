
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

    private static int playerPosition = 0;
    private static int currentLevel = 1;
    private static GameState gameState = GameState.Unknown;

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

        while (true)
        {
            var input = Console.ReadLine();

            // End of standard input; exit program.
            if (input == null)
                return;

            PerformUpdates(input);

            switch (gameState)
            {
                case GameState.GamePlay:
                    await RenderGameplay(socket, currentLevel, playerPosition);
                    break;
                case GameState.TubeDecent:
                    await RenderTubeDecent(socket, currentLevel, playerPosition);
                    break;
                case GameState.LevelTransition:
                    await RenderLevelTransition(socket, currentLevel, playerPosition);
                    break;
            }
        }
    }

    private static void PerformUpdates(string input)
    {
        var isGameState = input.StartsWith("Game State: ");

        if (isGameState)
        {
            UpdateGameState(input);
        }

        var isPlayerPosition = input.StartsWith("Player Position: ");

        if (isPlayerPosition)
        {
            UpdatePlayerPosition(input);
        }
    }

    private static void UpdateGameState(string message)
    {
        var parts = message.Split("Game State: ");

        if (parts.Length != 2)
            return;

        switch (parts[1])
        {
            case "game-play":
                gameState = GameState.GamePlay;
                break;
            case "tube-decent":
                gameState = GameState.TubeDecent;
                break;
            case "level-transition":
                gameState = GameState.LevelTransition;
                break;
        }
    }

    private static void UpdatePlayerPosition(string message)
    {
        var parts = message.Split("Player Position: ");

        if (parts.Length != 2)
            return;

        var parsedOk = int.TryParse(parts[1], out int position);

        if (parsedOk)
            playerPosition = position;
    }

    private static async Task<Socket> Connect(string ipAddress, int port)
    {
        var ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
        var client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        await client.ConnectAsync(ipEndPoint);
        return client;
    }

    private static async Task RenderTubeDecent(Socket socket, int level, int position)
    {
        // TODO: Extra bright level tiles fading in and out? Use Purple for testing.
        var colors = new List<Color>();

        for (var i = 0; i < LED_COUNT; i++)
            colors.Add(Color.Purple);

        await Render(socket, colors);
    }

    private static async Task RenderLevelTransition(Socket socket, int level, int position)
    {
        // TODO: Mostly black with rainbow specs fading in and out? Use White for testing.
        var colors = new List<Color>();

        for (var i = 0; i < LED_COUNT; i++)
            colors.Add(Color.White);

        await Render(socket, colors);
    }

    private static async Task RenderGameplay(Socket socket, int level, int position)
    {
        var colors = new List<Color>();
        var ledIndicies = GetLedIndiciesForPlayer(level, position);
        var colorSet = ColorMaps.Mapping[level];

        for (var i = 0; i < LED_COUNT; i++)
        {
            if (ledIndicies.Contains(i))
            {
                // Player occupied level segment
                colors.Add(colorSet.Player);
            }
            else
            {
                // Unoccupied level segment
                colors.Add(colorSet.Level);
            }
        }

        await Render(socket, colors);
    }

    private static List<int> GetLedIndiciesForPlayer(int level, int position)
    {
        var levelMap = LevelMaps.Mapping[level];
        var positionMap = levelMap[position];
        return positionMap;
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
