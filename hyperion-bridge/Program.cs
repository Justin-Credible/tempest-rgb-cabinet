
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

    private static bool zapperActive = false;
    private static int zapperFrameCounter = 0;
    private static bool zapperUseBaseColor = true;
    private static int zapperColorIndex = 0;

    private static int explosionFrameCounter = 0;
    private static int explosionColorIndex = 0;

    private static DeathState deathState = DeathState.None;

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

            var message = ParseMessage(input);

            if (message == null)
                continue;

            HandleUpdates(message.Value);
            await HandleRendering(socket);
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
        var colorSet = ColorMaps.Mapping[1];

        var location = 0;
        var incrementBy = 1;
        var range = 3;

        while (true)
        {
            var colors = new List<Color>();

            for (var i = 0; i < LED_COUNT; i++)
            {
                if (location >= i - range && location <= i + range)
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

            location += incrementBy;

            if (location >= 56 || location <= 0)
                incrementBy = incrementBy * -1;

            Thread.Sleep(100);
        }
    }

    private static Message? ParseMessage(string input)
    {
        var parts = input.Split(':');

        if (parts.Length >= 2)
            return null;

        var x = new Message { Command = parts[0], Argument = parts[1] };
        return x;
    }

    private static void HandleUpdates(Message message)
    {
        switch(message.Command)
        {
            case "game-state":
                UpdateGameState(message.Argument);
                break;
            case "current-level":
                UpdateCurrentLevel(message.Argument);
                break;
            case "player-position":
                UpdatePlayerPosition(message.Argument);
                break;
            case "zapper":
                UpdateZapperState(message.Argument);
                break;
            case "death-state":
                UpdateDeathState(message.Argument);
                break;
        }
    }

    private static void UpdateGameState(string stateName)
    {
        switch (stateName)
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
            default:
                gameState = GameState.Unknown;
                break;
        }
    }

    private static void UpdateCurrentLevel(string levelString)
    {
        var parsedOk = int.TryParse(levelString, out int position);

        if (parsedOk)
            currentLevel = position;
    }

    private static void UpdatePlayerPosition(string positionString)
    {
        var parsedOk = int.TryParse(positionString, out int position);

        if (parsedOk)
            playerPosition = position;
    }

    private static void UpdateZapperState(string zapperStateString)
    {
        zapperActive = zapperStateString == "active" ? true : false;
    }

    private static void UpdateDeathState(string deathStateString)
    {
        switch (deathStateString)
        {
            case "0":
                deathState = DeathState.None;
                break;
            case "1":
                deathState = DeathState.ShipCapture;
                break;
            case "2":
                deathState = DeathState.ShipExplosion;
                break;
        }
    }

    private static async Task HandleRendering(Socket socket)
    {
        switch (gameState)
        {
            case GameState.GamePlay:
                await RenderGameplay(socket);
                break;
            case GameState.TubeDecent:
                await RenderTubeDecent(socket);
                break;
            case GameState.LevelTransition:
                await RenderLevelTransition(socket);
                break;
        }
    }

    private static async Task RenderTubeDecent(Socket socket)
    {
        // TODO: Extra bright level tiles fading in and out? Use margenta for testing.
        var colors = new List<Color>();

        for (var i = 0; i < LED_COUNT; i++)
            colors.Add(Color.Magenta);

        await Render(socket, colors);
    }

    private static async Task RenderLevelTransition(Socket socket)
    {
        // TODO: Mostly black with rainbow specs fading in and out? Use white for testing.
        var colors = new List<Color>();

        for (var i = 0; i < LED_COUNT; i++)
            colors.Add(Color.White);

        await Render(socket, colors);
    }

    private static async Task RenderGameplay(Socket socket)
    {
        var colors = new List<Color>();
        var ledIndicies = Utilities.GetLedIndiciesForPlayer(currentLevel, playerPosition);
        var colorSet = ColorMaps.Mapping[currentLevel];

        // Frame counter bookkeeping for animations etc.
        if (deathState == DeathState.ShipCapture)
        {
            // TODO: Framecounter bookeeping
        }
        else if (deathState == DeathState.ShipExplosion)
        {
            if (explosionFrameCounter >= 4)
            {
                explosionFrameCounter = 0;
                explosionColorIndex++;

                if (explosionColorIndex >= 3)
                    explosionColorIndex = 0;
            }
            else
            {
                explosionFrameCounter++;
            }
        }
        else if (zapperActive)
        {
            if (zapperFrameCounter >=4)
            {
                // Every 4 frames cycle between the base color set and the random color.
                zapperFrameCounter = 0;
                zapperUseBaseColor = !zapperUseBaseColor;

                // If we're not using the base color, increment to the next random color.
                if (!zapperUseBaseColor)
                {
                    if (zapperColorIndex >= 7)
                        zapperColorIndex = 0;
                    else
                        zapperColorIndex++;
                }
            }
            else
            {
                zapperFrameCounter++;
            }
        }

        // Specify the color of each RGB LED in the strip.
        for (var i = 0; i < LED_COUNT; i++)
        {
            if (deathState == DeathState.ShipCapture)
            {
                // TODO: Ramp up to full level color brightness, then fade to black
                colors.Add(Color.BrightMagenta);
            }
            else if (deathState == DeathState.ShipExplosion)
            {
                // Ship explosion, strobe explosion colors
                colors.Add(Utilities.GetExplosionColor(explosionColorIndex));
            }
            else if (zapperActive)
            {
                // Zapper active, strobe color effect
                colors.Add(zapperUseBaseColor ? colorSet.Level : Utilities.GetZapperColor(zapperColorIndex));
            }
            else if (ledIndicies.Contains(i))
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
}
