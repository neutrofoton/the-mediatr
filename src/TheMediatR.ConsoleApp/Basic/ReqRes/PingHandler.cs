using MediatR;
using TheMediatR.ConsoleApp.Basic.ReqRes;

namespace TheMediatR.ConsoleApp.Basic.ReqRes;

public class PingHandler : IRequestHandler<PingRequest, PingResponse>
{
    public Task<PingResponse> Handle(PingRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new PingResponse()
        {
            Message = $"Response of {nameof(request)}"
        });
    }
}
