using System.Runtime.CompilerServices;
using MediatR;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Streams;

namespace TheMediatR.ConsoleApp;

public class StreamDemo: Demo
{
    public StreamDemo(ILogger<StreamDemo> logger, IMediator mediator): base(logger,mediator)
    {
    }

    public override async void Show()
    {
        
        logger.LogTrace($"------------------------------");

        CancellationToken cancellationToken = new CancellationToken(false);

        await Task.Run(async () =>
        {
           
            await foreach (var response in mediator.CreateStream<MyStreamResponse>(new MyStreamRequest(), cancellationToken))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Received Stream Count:{response.Count} Request Id:{response.RequestId}");
                Console.ForegroundColor = ConsoleColor.White;
            };

            Console.WriteLine($"Stream Request finished.");
        });
    }
}

