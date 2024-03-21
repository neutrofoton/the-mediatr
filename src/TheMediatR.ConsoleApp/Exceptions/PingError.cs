using MediatR;

namespace TheMediatR.ConsoleApp.Exceptions;

public class PingErrorRequest : IRequest<PingErrorResponse> 
{  
}

public class PingErrorResponse
{
    public string? Message {get;set;}
}

public class PingExceptionHandler : IRequestHandler<PingErrorRequest, PingErrorResponse>
{
    public Task<PingErrorResponse> Handle(PingErrorRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("Simulasi Demo Error Exception");
    }
}