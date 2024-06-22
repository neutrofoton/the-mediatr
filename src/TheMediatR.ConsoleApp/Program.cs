
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp;
using TheMediatR.ConsoleApp.Basic.ReqRes;
using TheMediatR.ConsoleApp.Exceptions;
using TheMediatR.ConsoleApp.Pipelines.Behaviors;
using TheMediatR.ConsoleApp.TheCaller;

IConfiguration configuration = new ConfigurationBuilder()
                .Build();

IServiceProvider serviceProvider = new ServiceCollection()
    .AddValidatorsFromAssemblies(new []{ Assembly.GetExecutingAssembly()})
    .AddLogging(options =>
    {
        options.ClearProviders();
        options.AddConsole();
        options.SetMinimumLevel(LogLevel.Trace);
    })
    .AddMediatR(cfg => {
        cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        //cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

        //Just register the behaviors in the order you would like them to be called. 
        //For void handlers, the type of TResponse will be Unit.
        
        //cfg.AddRequestPreProcessor(typeof(GenericRequestPreProcessor<>));
        cfg.AddOpenRequestPreProcessor(typeof(GenericRequestPreProcessor<>));
        cfg.AddOpenRequestPostProcessor(typeof(GenericRequestPostProcessor<,>));

        cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        cfg.AddOpenStreamBehavior(typeof(GenericStreamPipelineBehavior<,>)); 
           
        
    })
    //.AddTransient(typeof(GlobalRequestExceptionHandler<,,>))
    .AddTransient<BasicOneWayDemo>()
    .AddTransient<BasicReqResDemo>()
    .AddTransient<NotificationDemo>()
    .AddTransient<ExceptionDemo>()
    .AddTransient<StreamDemo>()
    .AddTransient<ValidatorDemo>()
    .BuildServiceProvider();

Console.WriteLine();

await serviceProvider.GetRequiredService<BasicOneWayDemo>().Show();
Console.WriteLine(Environment.NewLine+Environment.NewLine);

await serviceProvider.GetRequiredService<BasicReqResDemo>().Show();
Console.WriteLine(Environment.NewLine+Environment.NewLine);

await serviceProvider.GetRequiredService<NotificationDemo>().Show();
Console.WriteLine(Environment.NewLine+Environment.NewLine);

await serviceProvider.GetRequiredService<ExceptionDemo>().Show();
Console.WriteLine(Environment.NewLine+Environment.NewLine);

await serviceProvider.GetRequiredService<ValidatorDemo>().Show();
Console.WriteLine(Environment.NewLine+Environment.NewLine);

await serviceProvider.GetRequiredService<StreamDemo>().Show();
Console.WriteLine(Environment.NewLine+Environment.NewLine);

await Task.Delay(10000);