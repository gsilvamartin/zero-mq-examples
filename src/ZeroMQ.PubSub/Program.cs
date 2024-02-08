using ZeroMQ.PubSub;

public class Program
{
    public static void Main(string[] args)
    {
        Task.Run(ZeroMQPubSubPublisher.RegisterZeroMQPublisher);
        Task.Run(ZeroMQPubSubConsumer.RegisterZeroMQConsumer);

        Console.WriteLine("Press enter to exit the program");
        Console.ReadKey();
    }
}
