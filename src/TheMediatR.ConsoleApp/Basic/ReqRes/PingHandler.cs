using MediatR;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Basic.ReqRes;

namespace TheMediatR.ConsoleApp.Basic.ReqRes;

public class PingHandler : IRequestHandler<PingRequest, PingResponse>
{
    private readonly ILogger<PingHandler> logger;
    public PingHandler(ILogger<PingHandler> logger)
    {
        this.logger=logger;
    }

    public Task<PingResponse> Handle(PingRequest request, CancellationToken cancellationToken)
    {
        logger.LogDebug($"[REQ-RES] Do task on {this.GetType().Name}");
        
        return Task.FromResult(new PingResponse()
        {
            Message = $"Response of {nameof(request)}"
        });
    }
}
