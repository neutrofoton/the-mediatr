using MediatR;

namespace TheMediatR.ConsoleApp.Basic.ReqRes;

public class PingRequest : IRequest<PingResponse> 
{  
}

public class PingResponse
{
    public string? Message {get;set;}
}