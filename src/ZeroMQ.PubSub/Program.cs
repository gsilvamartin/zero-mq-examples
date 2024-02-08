namespace ZeroMQ.PubSub;

/// <summary>
/// Represents the entry point of the ZeroMQ PUB-SUB example program.
/// 
/// This program demonstrates the ZeroMQ PUB-SUB pattern where a publisher sends messages to all connected subscribers.
/// Subscribers receive messages based on their subscriptions.
/// </summary>
public class Program
{
    /// <summary>
    /// The main entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        // Run the ZeroMQ PUB-SUB publisher and consumer concurrently
        Task.Run(ZeroMQPubSubPublisher.RegisterZeroMQPublisher);
        Task.Run(ZeroMQPubSubConsumer.RegisterZeroMQConsumer);

        Console.WriteLine("Press enter to exit the program");
        Console.ReadKey();
    }
}
