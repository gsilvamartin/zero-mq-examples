using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroMQ.PushPull;

/// <summary>
/// Represents a ZeroMQ PUSH-PULL pattern puller.
/// </summary>
public class ZeroMQPushPullPuller
{
    private static readonly string _pullerUrl = "tcp://127.0.0.1:5556";

    /// <summary>
    /// Receives messages in the ZeroMQ PUSH-PULL pattern.
    /// </summary>
    public static void RegisterZeroMQPuller()
    {
        using (var puller = new PullSocket())
        {
            puller.Bind(_pullerUrl);

            Console.WriteLine("Puller: Ready to receive messages.");

            for (int i = 0; i < int.MaxValue; i++)
            {
                string message = puller.ReceiveFrameString();
                Console.WriteLine($"Received message: {message}");
            }

            Console.WriteLine("Puller: Finished receiving messages.");
        }
    }
}


