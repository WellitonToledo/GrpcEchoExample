using System.Diagnostics;
using Grpc.Net.Client;
using GrpcEchoExample;

//var channel = GrpcChannel.ForAddress("http://localhost:5062");
var channel = GrpcChannel.ForAddress("https://accessservice-api.stage.toletus.cloud");
var client = new EchoService.EchoServiceClient(channel);

Console.WriteLine("gRPC Client started. Type 'exit' to stop.");

while (true)
{
    Console.WriteLine("Enter a message to send to the server:");
    var message = Console.ReadLine();

    // Check if the user wants to exit the client
    if (message?.ToLower() == "exit")
    {
        Console.WriteLine("Closing client...");
        break;
    }

    // Create the request with the user's message
    var request = new EchoRequest { Message = message };

    // Start the stopwatch to measure the round-trip time
    var stopwatch = Stopwatch.StartNew();

    try
    {
        // Send the request to the gRPC server
        var reply = await client.EchoAsync(request);

        // Stop the stopwatch after receiving the response
        stopwatch.Stop();

        // Display the server's response and the latency
        Console.WriteLine($"Server responded: {reply.Message}");
        Console.WriteLine($"Round-trip latency: {stopwatch.ElapsedMilliseconds} ms");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error communicating with the server: {ex.Message}");
    }
}