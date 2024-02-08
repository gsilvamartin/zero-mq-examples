using System;
using System.Threading.Tasks;

namespace ZeroMQ.ReqRep;

/// <summary>
/// This program demonstrates the ZeroMQ REQ-REP pattern.
/// 
/// The REQ-REP pattern involves a requester (client) that sends requests to a responder (server).
/// The responder processes these requests and sends back replies to the requester.
/// 
/// In this example, the program creates a requester and a responder running concurrently in separate threads.
/// The requester sends a series of requests to the responder, which processes the requests and sends back replies.
/// Both sides communicate using ZeroMQ sockets and the REQ-REP pattern.
/// </summary>
public class Program
{
    /// <summary>
    /// The main entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        // Run the ZeroMQ REQ-REP requester and responder concurrently
        Task.Run(ZeroMQReqRepRequester.RegisterZeroMQRequester);
        Task.Run(ZeroMQReqRepResponder.RegisterZeroMQResponder);

        Console.WriteLine("Press enter to exit the program");
        Console.ReadLine();
    }
}

