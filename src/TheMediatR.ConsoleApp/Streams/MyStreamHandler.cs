using MediatR;

namespace TheMediatR.ConsoleApp.Streams;

public class MyStreamHandler : IStreamRequestHandler<MyStreamRequest, MyStreamResponse>
{
    private int _count;
    public async IAsyncEnumerable<MyStreamResponse> Handle(MyStreamRequest request, CancellationToken cancellationToken)
   {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(500, cancellationToken);
            _count++;

            yield return new MyStreamResponse(request.Id, _count);

            if (_count == 10)
            {
                break;
            }
        }
    }
}
