using MediatR;

namespace TheMediatR.ConsoleApp.Streams;


public class MyStreamRequest : IStreamRequest<MyStreamResponse> 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int RequestCount {get;set;}
}
public class MyStreamResponse
{
    public MyStreamResponse(Guid requestId, int requestCount, int responseCount)
    {
        RequestId = requestId;
        RequestCount = requestCount;

        ResponseCount = responseCount;
    }
    public Guid RequestId { get; set; }
    public int RequestCount { get; set; }
    public int ResponseCount { get; set; }

}