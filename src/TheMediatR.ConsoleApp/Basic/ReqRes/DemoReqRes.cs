using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp.Basic.ReqRes;

public class DemoReqRes : Demo
{
    public DemoReqRes(ILogger<DemoReqRes> logger, IMediator mediator): base(logger,mediator)
    {
    }

    public override async void Show()
    {
        PingResponse response = await mediator.Send(new PingRequest() { });

        logger.LogDebug($"-> {response.Message}");
        
    }
}

