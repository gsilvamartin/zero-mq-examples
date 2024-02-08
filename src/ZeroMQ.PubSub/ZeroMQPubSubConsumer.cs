using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroMQ.PubSub;

public class ZeroMQPubSubConsumer
{
    private static readonly string _consumerUrl = "tcp://127.0.0.1:5556";

    public static void RegisterZeroMQConsumer()
    {
        using (var subscriber = new SubscriberSocket())
        {
            subscriber.Connect(_consumerUrl);
            subscriber.Subscribe("");

            Console.WriteLine("Subscriber: Ready to receive messages.");

            while (true)
            {
                string message = subscriber.ReceiveFrameString();
                Console.WriteLine($"Received: {message}");
            }
        }
    }
}
