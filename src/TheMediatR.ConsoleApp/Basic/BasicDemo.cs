using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Basic.ReqNoRes;

namespace TheMediatR.ConsoleApp.Basic.ReqRes;

public class BasicDemo : Demo
{
    public BasicDemo(ILogger<BasicDemo> logger, IMediator mediator): base(logger,mediator)
    {
    }

    public override async void Show()
    {
        PingResponse response = await mediator.Send(new PingRequest() { });
        logger.LogInformation($"Ping -> {response.Message}");

        
        logger.LogTrace($"------------------------------");

        await mediator.Send(new OneWayRequest(){});
        logger.LogInformation($"OneWayRequest -> No Return");
    }
}

