using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace DotnetCoreApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c => { c.AddEnvironmentVariables(); })
                .UseStartup<Startup>()
                .UseKestrel()
                .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .Enrich.FromLogContext());
        }           
    }
}
