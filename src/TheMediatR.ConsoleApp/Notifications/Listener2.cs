using MediatR;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp;

public class Listener2 : INotificationHandler<Announcement>
{
    private ILogger<Listener2> logger;
    private IMediator mediator;
    public Listener2(ILogger<Listener2> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    public async Task Handle(Announcement notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Announcement received by {nameof(Listener2)} is {notification.Message}");
        
        await Task.Delay(1000,cancellationToken);

        //republish
        logger.LogInformation($"Then Listener2 re-announce");

        await mediator.Publish<AnnouncementExt>(new (){
                Message = notification.Message + "--Ext"
            },cancellationToken);

    }
}