using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp;

public class GenericRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    where TRequest : notnull
{
    private ILogger<GenericRequestPostProcessor<TRequest, TResponse>> logger;
    public GenericRequestPostProcessor(ILogger<GenericRequestPostProcessor<TRequest, TResponse>> logger)
    {
        this.logger = logger;
    }
    public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
    {
        logger.LogTrace($"[POST-Processor] => of Request = {nameof(request)} , Response = {nameof(response)}");
        
        return Task.CompletedTask;
    }
}
