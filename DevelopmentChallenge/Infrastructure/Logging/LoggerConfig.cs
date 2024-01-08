using Serilog;

namespace DevelopmentChallenge.Infrastructure.Logging
{
    public static class LoggerConfig
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
