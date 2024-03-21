using System.Runtime.CompilerServices;
using MediatR;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Streams;

namespace TheMediatR.ConsoleApp;

public class GenericStreamPipelineBehavior<TRequest, TResponse> : IStreamPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
        private ILogger<GenericStreamPipelineBehavior<TRequest, TResponse>> logger;

    public GenericStreamPipelineBehavior(ILogger<GenericStreamPipelineBehavior<TRequest, TResponse>> logger)
    {
        this.logger = logger;
    }

    public async IAsyncEnumerable<TResponse> Handle(TRequest request, StreamHandlerDelegate<TResponse> next, [EnumeratorCancellation]CancellationToken cancellationToken)
    {
        logger.LogTrace("-- Start Stream Behavior");
        
        await foreach (var response in next().WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            if(response is MyStreamResponse) 
            {
                int resCount = (response! as MyStreamResponse)!.ResponseCount;
                logger.LogTrace($"-- In Stream Behavior {resCount}");
            }
            yield return response;
        }

        logger.LogTrace("-- Finished Stream Behavior");
    }
}