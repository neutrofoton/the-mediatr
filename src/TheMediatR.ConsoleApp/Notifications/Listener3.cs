using MediatR;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp;

public class Listener3 : INotificationHandler<Announcement>, INotificationHandler<AnnouncementExt>
{
    private ILogger<Listener3> logger;
    public Listener3(ILogger<Listener3> logger)
    {
        this.logger = logger;
    }
   
    public Task Handle(Announcement notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Announcement received by {nameof(Listener3)} is {notification.Message}");
        
        return Task.CompletedTask;
    }

    public Task Handle(AnnouncementExt notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"AnnouncementExt received by {nameof(Listener3)} is {notification.Message}");
        
        return Task.CompletedTask;
    }

   
}
