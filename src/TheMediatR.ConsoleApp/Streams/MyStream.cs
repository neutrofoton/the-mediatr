using MediatR;

namespace TheMediatR.ConsoleApp.Streams;


public class MyStreamRequest : IStreamRequest<MyStreamResponse> 
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
public class MyStreamResponse
{
    public MyStreamResponse(Guid requestId, int count)
    {
        RequestId = requestId;
        Count = count;
    }
    public Guid RequestId { get; set; }
    public int Count { get; set; }
}