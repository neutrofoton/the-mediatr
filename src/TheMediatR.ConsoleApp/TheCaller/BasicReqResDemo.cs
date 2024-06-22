using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Basic.ReqNoRes;
using TheMediatR.ConsoleApp.Basic.ReqRes;

namespace TheMediatR.ConsoleApp.TheCaller;

public class BasicReqResDemo : Demo
{
    public BasicReqResDemo(ILogger<BasicReqResDemo> logger, IMediator mediator): base(logger,mediator)
    {
    }

    public override async Task Show()
    {
        logger.LogInformation($"[Caller] ReqRes START");

        PingResponse response = await mediator.Send(new PingRequest() { });

        await Task.Delay(500);
        
        logger.LogInformation($"[Caller] ReqRes FINISH -> {response.Message}");

    }
}

