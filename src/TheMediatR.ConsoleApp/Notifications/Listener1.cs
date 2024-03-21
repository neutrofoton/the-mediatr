using MediatR;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp;

public class Listener1 : INotificationHandler<Announcement>
{
    private ILogger<Listener1> logger;
    public Listener1(ILogger<Listener1> logger)
    {
        this.logger = logger;
    }

    public Task Handle(Announcement notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Announcement received by {nameof(Listener1)} is {notification.Message}");
        
        return Task.CompletedTask;
    }
}
