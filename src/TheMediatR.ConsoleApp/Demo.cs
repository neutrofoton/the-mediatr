using MediatR;
using Microsoft.Extensions.Logging;

namespace TheMediatR.ConsoleApp;

public abstract class Demo
{
    protected readonly ILogger logger;
    protected readonly IMediator mediator;
    public Demo(ILogger<Demo> logger, IMediator mediator)
    {
        this.logger=logger;
        this.mediator = mediator;
    }

    public abstract void Show();
}
