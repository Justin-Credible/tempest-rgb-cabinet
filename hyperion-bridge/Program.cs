
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    public static void Main()
    {
        DoWork().Wait();
    }

    // G R B

    public static async Task DoWork()
    {
        Console.WriteLine("Starting...");

        IPEndPoint ipEndPoint = new(IPAddress.Parse("127.0.0.1"), 19444);

        using Socket client = new(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        await client.ConnectAsync(ipEndPoint);

        var json1 = "{\"command\": \"color\", \"color\": [0,0,255], \"priority\": 50, \"origin\": \"test command line\"}\r\n";
        var messageBytes1 = Encoding.ASCII.GetBytes(json1);
        var result1 = await client.SendAsync(messageBytes1, SocketFlags.None);

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
                    sb.Append("0,0,0");
                }
                else if (location >= i - range && location <= i + range)
                {
                    sb.Append("192,192,0");
                }
                else
                {
                    // sb.Append("0,0,255");
                    sb.Append("0,0,128");
                }
            }

            var colorJson = sb.ToString();
            var json2 = "{\"command\": \"color\", \"color\": [" + colorJson + "], \"priority\": 50, \"origin\": \"test command line\"}\r\n";
            var messageBytes2 = Encoding.ASCII.GetBytes(json2);
            var result2 = await client.SendAsync(messageBytes2, SocketFlags.None);

            location += incrementBy;

            if (location >= 56 || location <= 0)
            {
                incrementBy = incrementBy * -1;
            }

            System.Threading.Thread.Sleep(25);
            // System.Threading.Thread.Sleep(5);
        }
    }
}
