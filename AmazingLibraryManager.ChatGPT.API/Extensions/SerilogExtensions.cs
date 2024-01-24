using Serilog;

namespace AmazingLibraryManager.ChatGPT.API.Extensions
{
    public static class SerilogExtensions
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, IConfiguration configuration,
            string appName) 
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            builder.Logging.ClearProviders();
            builder.Host.UseSerilog(Log.Logger, true);

            return builder;
        }
    }
}