using MediatR;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp.Basic.ReqNoRes;

public class OneWayHandler : IRequestHandler<OneWayRequest>
{
    private readonly ILogger<OneWayHandler> logger;
    public OneWayHandler(ILogger<OneWayHandler> logger)
    {
        this.logger=logger;
    }

    public Task Handle(OneWayRequest request, CancellationToken cancellationToken)
    {
        // do work
        logger.LogDebug($"[ONE WAY] Do task on {this.GetType().Name}");
        return Task.CompletedTask;
    }
}
