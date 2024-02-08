using NetMQ;
using NetMQ.Sockets;
using System;
using System.Threading;

namespace ZeroMQ.PushPull;

/// <summary>
/// Represents a ZeroMQ PUSH-PULL pattern pusher.
/// </summary>
public class ZeroMQPushPullPusher
{
    private static readonly string _pusherUrl = "tcp://127.0.0.1:5556";

    /// <summary>
    /// Sends messages to the ZeroMQ PUSH-PULL pattern puller.
    /// </summary>
    public static void RegisterZeroMQPusher()
    {
        using (var pusher = new PushSocket())
        {
            pusher.Connect(_pusherUrl);

            Console.WriteLine("Pusher: Ready to send messages.");

            for (int i = 0; i < int.MaxValue; i++)
            {
                string message = $"Message {i}";
                Console.WriteLine($"Sending message: {message}");

                pusher.SendFrame(message);

                Thread.Sleep(1000);
            }

            Console.WriteLine("Pusher: Finished sending messages.");
        }
    }
}

