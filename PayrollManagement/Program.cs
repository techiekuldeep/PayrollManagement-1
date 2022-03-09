
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PayrollManagement.Services;
using Serilog;
using System;
using System.IO;

namespace PayrollManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    //adding configuration details to CSV file path
                    var opts = context.Configuration.GetSection("CsvOptions").Get<CsvOptions>();
                    services.AddSingleton(opts);
                    //all services are registered here
                    services.AddScoped<IEmployeeService, EmployeeService>();
                    services.AddScoped<ICsvReaderWriterService, CsvReaderWriterService>();
                    services.AddScoped<IMathRoundService, MathRoundService>();
                    services.AddScoped<IPayeTaxService, PayeTaxRateService>();
                    services.AddScoped(typeof(PayrollRunner));
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<PayrollRunner>(host.Services);
            svc.Run();
           
        }
        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
