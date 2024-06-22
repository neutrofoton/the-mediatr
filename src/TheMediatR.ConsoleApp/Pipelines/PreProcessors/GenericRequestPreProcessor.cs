using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp;

public class GenericRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest> 
    where TRequest : notnull
{
    private ILogger<GenericRequestPreProcessor<TRequest>> logger;
    public GenericRequestPreProcessor(ILogger<GenericRequestPreProcessor<TRequest>> logger)
    {
        this.logger = logger;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        logger.LogTrace($"[PRE-Processor] => of {(request)}");
        
        return Task.CompletedTask;
    }
}
