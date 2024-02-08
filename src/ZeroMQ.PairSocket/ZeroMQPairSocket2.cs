using NetMQ;
using NetMQ.Sockets;
using System;
using System.Threading;

namespace ZeroMQ.Pair;

/// <summary>
/// Represents a ZeroMQ PAIR pattern socket (Socket 1).
/// </summary>
public class ZeroMQPairSocket2
{
    private static readonly string _pairSocket2Url = "tcp://127.0.0.1:5556";

    /// <summary>
    /// Runs the ZeroMQ PAIR socket (Socket 1).
    /// </summary>
    public static void RegisterZeroMQPairSocket()
    {
        using (var pairSocket2 = new PairSocket())
        {
            pairSocket2.Bind(_pairSocket2Url);

            Console.WriteLine("PAIR Socket 2: Ready to send and receive messages.");

            for (int i = 0; i < int.MaxValue; i++)
            {
                string messageToSend = $"Message from Socket 2, Iteration {i}";
                Console.WriteLine($"PAIR Socket 2: Sending: {messageToSend}");

                pairSocket2.SendFrame(messageToSend);

                Thread.Sleep(1000);

                string receivedMessage = pairSocket2.ReceiveFrameString();
                Console.WriteLine($"PAIR Socket 2: Received: {receivedMessage}");
            }

            Console.WriteLine("PAIR Socket 2: Finished sending and receiving messages.");
        }
    }
}

