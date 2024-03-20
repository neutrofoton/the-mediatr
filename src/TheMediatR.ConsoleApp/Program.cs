
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheMediatR.ConsoleApp.Basic.ReqRes;

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
    })
    .AddTransient<BasicDemo>()
    .BuildServiceProvider();

Console.WriteLine();

serviceProvider.GetRequiredService<BasicDemo>().Show();