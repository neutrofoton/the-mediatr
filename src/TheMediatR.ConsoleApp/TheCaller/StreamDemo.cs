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


        await Task.Run(async () =>
        {
            CancellationTokenSource cts = new();
           
            int counter=0;
            await foreach (var response in mediator.CreateStream<MyStreamResponse>(
                new MyStreamRequest()
                { 
                    RequestCount = counter
                }, cts.Token))
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Received Stream with Response:{response.ResponseCount} from Request:{response.RequestCount} - {response.RequestId}");
                Console.ForegroundColor = ConsoleColor.White;

                if(counter>9)
                {
                    cts.Cancel();
                }
                counter++;
            };

            Console.WriteLine($"Stream Request finished.");
        });
    }
}

