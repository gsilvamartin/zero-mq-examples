using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroMQ.PubSub;

/// <summary>
/// Represents a ZeroMQ PUB-SUB pattern publisher.
/// </summary>
public class ZeroMQPubSubPublisher
{
    private static readonly string _publisherUrl = "tcp://127.0.0.1:5556";

    /// <summary>
    /// Registers the ZeroMQ publisher and starts sending messages in a PUB-SUB pattern.
    /// </summary>
    public static void RegisterZeroMQPublisher()
    {
        using (var publisher = new PublisherSocket())
        {
            publisher.Bind(_publisherUrl);

            Console.WriteLine("Publisher: Ready to send messages.");

            for (int i = 0; i < int.MaxValue; i++)
            {
                string message = $"Message {i}";
                Console.WriteLine($"Sending: {message}");
                publisher.SendFrame(message);

                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }
    }
}

