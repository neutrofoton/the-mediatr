using MediatR;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Exceptions;

namespace TheMediatR.ConsoleApp.TheCaller;

public class ExceptionDemo: Demo
{
    public ExceptionDemo(ILogger<ExceptionDemo> logger, IMediator mediator): base(logger,mediator)
    {
    }

    public override async Task Show()
    {
        PingErrorResponse response = await mediator.Send(new PingErrorRequest() { });

        await Task.Delay(500);
        
        logger.LogInformation($"[Caller] ReqResError -> {response.Message}");

    }
}