using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Basic.ReqNoRes;
using TheMediatR.ConsoleApp.Basic.ReqRes;

namespace TheMediatR.ConsoleApp.TheCaller;

public class BasicOneWayDemo : Demo
{
    public BasicOneWayDemo(ILogger<BasicOneWayDemo> logger, IMediator mediator): base(logger,mediator)
    {
    }

    public override async Task Show()
    {
        logger.LogInformation($"[Caller] OneWayRequest Start -> No Return");

        await mediator.Send(new OneWayRequest(){});
        
        logger.LogInformation($"[Caller] OneWayRequest Finish -> No Return");
        
    }
}

