using System;
using System.Threading.Tasks;

namespace ZeroMQ.PushPull;

/// <summary>
/// Represents the entry point of the ZeroMQ PUSH-PULL example program.
/// </summary>
///
/// This program demonstrates the ZeroMQ PUSH-PULL pattern where a pusher sends messages to a puller.
/// The puller receives messages asynchronously.
/// 
/// In this example, the program creates a pusher and a puller running concurrently in separate threads.
/// The pusher sends a series of messages, and the puller receives messages as they arrive.
/// Both sides communicate using ZeroMQ sockets and the PUSH-PULL pattern.
public class Program
{
    /// <summary>
    /// The main entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        // Run the ZeroMQ PUSH-PULL pusher and puller concurrently
        Task.Run(ZeroMQPushPullPusher.RegisterZeroMQPusher);
        Task.Run(ZeroMQPushPullPuller.RegisterZeroMQPuller);

        Console.WriteLine("Press enter to exit the program");
        Console.ReadLine();
    }
}
