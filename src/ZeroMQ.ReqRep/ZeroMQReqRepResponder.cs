using NetMQ;
using NetMQ.Sockets;
using System;

namespace ZeroMQ.ReqRep;

/// <summary>
/// Represents a ZeroMQ REQ-REP pattern responder (server).
/// </summary>
public class ZeroMQReqRepResponder
{
    private static readonly string _serverUrl = "tcp://127.0.0.1:5556";

    /// <summary>
    /// Listens for incoming requests and sends responses in the ZeroMQ REQ-REP pattern.
    /// </summary>
    public static void RegisterZeroMQResponder()
    {
        using (var responder = new ResponseSocket())
        {
            responder.Bind(_serverUrl);

            Console.WriteLine("Responder: Ready to receive and process requests.");

            while (true)
            {
                string request = responder.ReceiveFrameString();
                Console.WriteLine($"Received request: {request}");

                string response = $"Response to {request}";
                Console.WriteLine($"Sending response: {response}");
                responder.SendFrame(response);
            }
        }
    }
}
