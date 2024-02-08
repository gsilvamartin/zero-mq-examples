using NetMQ;
using NetMQ.Sockets;
using System;

namespace ZeroMQ.ReqRep;

/// <summary>
/// Represents a ZeroMQ REQ-REP pattern requester (client).
/// </summary>
public class ZeroMQReqRepRequester
{
    private static readonly string _serverUrl = "tcp://127.0.0.1:5556";

    /// <summary>
    /// Sends requests to the ZeroMQ REQ-REP server
    /// </summary>
    public static void RegisterZeroMQRequester()
    {
        using (var requester = new RequestSocket())
        {
            requester.Connect(_serverUrl);

            Console.WriteLine("Requester: Ready to send requests.");

            // Simulate sending requests periodically
            for (int i = 0; i < int.MaxValue; i++)
            {
                string request = $"Request {i}";
                Console.WriteLine($"Sending request: {request}");
                requester.SendFrame(request);

                string response = requester.ReceiveFrameString();
                Console.WriteLine($"Received response: {response}");

                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }
    }
}
