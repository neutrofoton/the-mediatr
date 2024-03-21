using MediatR.Pipeline;
using Microsoft.Extensions.Logging;


namespace TheMediatR.ConsoleApp.Exceptions;

public class GlobalRequestExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TRequest : notnull
    where TResponse : GenericResponse, new()
    where TException : Exception
{
    private readonly ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> logger;
    public GlobalRequestExceptionHandler(ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> logger)
    {
        this.logger = logger;
    }
    public async Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, $"GenericRequestExceptionHandler translating exception to error {request.GetType().Name}");
       
        await Task.Delay(500);

        var translatedResponse = new TResponse
        {
            HasError = true,
            Message = "GenericRequestExceptionHandler handled this.",
        };

		// Also I noticed Post handlers will not run after this
		state.SetHandled(translatedResponse);
    }
}
