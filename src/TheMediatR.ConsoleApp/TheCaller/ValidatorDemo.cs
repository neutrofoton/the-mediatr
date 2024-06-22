using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Exceptions;

namespace TheMediatR.ConsoleApp;


public class SaveUserViewModel : IRequest<SaveUserResultViewModel>
{
    public string Name{ get; set; }
}

//inherit from GenericResponse to make it captured by global exception handler
public class SaveUserResultViewModel : GenericResponse
{
    public bool IsSuccess{ get; set; }
}

public class UserValidator : AbstractValidator<SaveUserViewModel>
{
    public UserValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(5)
            .WithMessage("Nama harus lebih dari 5 karakter");
    }
}

public class ValidatorDemo: Demo
{
    public ValidatorDemo(ILogger<ValidatorDemo> logger, IMediator mediator): base(logger,mediator)
    {
    }

    public override async Task Show()
    {
          logger.LogInformation($"[Caller] ValidatorReqRes START");

        SaveUserResultViewModel response = await mediator.Send(new SaveUserViewModel() {  Name = "helo"});

        await Task.Delay(500);
        
        logger.LogInformation($"[Caller] ValidatorReqRes FINISH -> {response.IsSuccess}");

    }
}

