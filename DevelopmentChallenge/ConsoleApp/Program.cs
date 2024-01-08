using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DevelopmentChallenge.ConsoleApp;
using DevelopmentChallenge.Application.Interfaces;
using DevelopmentChallenge.Application.UseCases;
using DevelopmentChallenge.Infrastructure.Logging;
using DevelopmentChallenge.Infrastructure.Localization;

class Program
{
    public static void Main()
    {
        ConfigureLogger();

        var host = CreateHostBuilder().Build();
        var app = host.Services.GetRequiredService<ConsoleApp>();
        app.Run();
    }

    public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                ConfigureServices(services);
            });

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IReporteFormasUseCase, ReporteFormasUseCase>();
        services.AddSingleton<IResourceProvider, IdiomaManagerResourceProvider>();
        services.AddScoped<ConsoleApp>();
    }

    private static void ConfigureLogger()
    {
        LoggerConfig.ConfigureLogger();
    }
}
