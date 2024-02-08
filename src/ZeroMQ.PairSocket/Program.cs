using System;
using System.Threading.Tasks;

namespace ZeroMQ.Pair;
/// <summary>
/// Represents the entry point of the ZeroMQ PAIR example program.
/// </summary>
/// 
/// This program demonstrates the ZeroMQ PAIR pattern where two sockets communicate bidirectionally.
/// Both sides can send and receive messages independently.
/// 
/// In this example, the program creates two PAIR sockets running concurrently in separate threads.
/// Both sides can send and receive messages independently using ZeroMQ sockets and the PAIR pattern.
public class Program
{
    /// <summary>
    /// The main entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        // Run the ZeroMQ PAIR sockets concurrently
        Task.Run(ZeroMQPairSocket1.RegisterZeroMQPairSocket);
        Task.Run(ZeroMQPairSocket2.RegisterZeroMQPairSocket);

        Console.WriteLine("Press enter to exit the program");
        Console.ReadLine();
    }
}
