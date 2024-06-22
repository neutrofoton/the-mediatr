using FluentValidation;
using MediatR;

namespace TheMediatR.ConsoleApp.Pipelines.Behaviors;

public class ValidationError
{
    public string? PropertyName {get;set;}
    public string? ErrorMessage {get;set;}
}


public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest: IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context))
        );

        var failures = validationResults
            .Where(vr => !vr.IsValid)
            .SelectMany(vr => vr.Errors)
            .Select(failure => failure)
            .ToList();

        if(failures.Any())
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}   
