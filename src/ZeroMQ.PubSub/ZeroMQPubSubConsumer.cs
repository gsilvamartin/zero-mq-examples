using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroMQ.PubSub
{
    public class ZeroMQPubSubConsumer
    {
        private readonly string _consumerUrl = "tcp://127.0.0.1:5556";

        public static CreateZeroMQConsumer()
        {
            using (var publisher = new PublisherSocket())
            {
                publisher.Bind("tcp://127.0.0.1:5556");

                Console.WriteLine("Publisher: Ready to send messages. Press Enter to exit.");

                // Simulate sending messages periodically
                for (int i = 0; i < 5; i++)
                {
                    string message = $"Message {i}";
                    Console.WriteLine($"Sending: {message}");
                    publisher.SendFrame(message);

                    System.Threading.Thread.Sleep(1000); // Simulate some processing time
                }

                Console.ReadLine(); // Wait for user input before exiting
            }
        }
    }
}
