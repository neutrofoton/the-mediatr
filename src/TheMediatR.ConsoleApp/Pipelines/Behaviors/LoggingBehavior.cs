using MediatR;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp.Pipelines.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        this.logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogCritical($"LoggingBehavior Handling BEFORE {typeof(TRequest).Name}");
        
        var response = await next();
        
        logger.LogCritical($"LoggingBehavior Handled AFTER {typeof(TResponse).Name}");

        return response;
    }
}