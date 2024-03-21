
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp;
using TheMediatR.ConsoleApp.Basic.ReqRes;
using TheMediatR.ConsoleApp.Pipelines.Behaviors;
using TheMediatR.ConsoleApp.TheCaller;

IConfiguration configuration = new ConfigurationBuilder()
                .Build();

IServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging(options =>
    {
        options.ClearProviders();
        options.AddConsole();
        options.SetMinimumLevel(LogLevel.Trace);
    })
    .AddMediatR(cfg => {
        cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        
    })
    .AddTransient<BasicDemo>()
    .AddTransient<NotificationDemo>()
    .AddTransient<StreamDemo>()
    .BuildServiceProvider();

Console.WriteLine();

serviceProvider.GetRequiredService<BasicDemo>().Show();
serviceProvider.GetRequiredService<NotificationDemo>().Show();
serviceProvider.GetRequiredService<StreamDemo>().Show();
await Task.Delay(10000);