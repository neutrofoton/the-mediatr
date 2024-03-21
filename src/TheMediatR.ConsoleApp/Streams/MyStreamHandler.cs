using System.Runtime.CompilerServices;
using MediatR;

namespace TheMediatR.ConsoleApp.Streams;

public class MyStreamHandler : IStreamRequestHandler<MyStreamRequest, MyStreamResponse>
{
    private int resCount;
    public async IAsyncEnumerable<MyStreamResponse> Handle(MyStreamRequest request, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(500, cancellationToken);
            resCount++;

            yield return new MyStreamResponse(request.Id, request.RequestCount, resCount);
        }
    }
}
