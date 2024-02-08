using NetMQ;
using NetMQ.Sockets;
using System;
using System.Threading;

namespace ZeroMQ.Pair;

/// <summary>
/// Represents a ZeroMQ PAIR pattern socket (Socket 1).
/// </summary>
public class ZeroMQPairSocket1
{
    private static readonly string _pairSocket1Url = "tcp://127.0.0.1:5556";

    /// <summary>
    /// Runs the ZeroMQ PAIR socket (Socket 1).
    /// </summary>
    public static void RegisterZeroMQPairSocket()
    {
        using (var pairSocket1 = new PairSocket())
        {
            pairSocket1.Bind(_pairSocket1Url);

            Console.WriteLine("PAIR Socket 1: Ready to send and receive messages.");

            for (int i = 0; i < int.MaxValue; i++)
            {
                string messageToSend = $"Message from Socket 1, Iteration {i}";
                Console.WriteLine($"PAIR Socket 1: Sending: {messageToSend}");

                pairSocket1.SendFrame(messageToSend);

                Thread.Sleep(1000);

                string receivedMessage = pairSocket1.ReceiveFrameString();
                Console.WriteLine($"PAIR Socket 1: Received: {receivedMessage}");
            }

            Console.WriteLine("PAIR Socket 1: Finished sending and receiving messages.");
        }
    }
}

