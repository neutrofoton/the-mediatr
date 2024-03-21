using MediatR;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp;

public class NotificationDemo : Demo
{
    public NotificationDemo(ILogger<NotificationDemo> logger, IMediator mediator): base(logger,mediator)
    {
    }

    public override async void Show()
    {
        logger.LogTrace($"------------------------------");

        await mediator.Publish(new Announcement(){
            Message = "Hello Announcement "
        });
        
    }
}
