using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Basic.ReqNoRes;
using TheMediatR.ConsoleApp.Basic.ReqRes;

namespace TheMediatR.ConsoleApp.TheCaller;

public class BasicOneWayDemo : Demo
{
    public BasicOneWayDemo(ILogger<BasicReqResDemo> logger, IMediator mediator): base(logger,mediator)
    {
    }

    public override async Task Show()
    {
        await mediator.Send(new OneWayRequest(){});
        logger.LogInformation($"[Caller] OneWayRequest -> No Return");
    }
}

