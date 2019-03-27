using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;

namespace TCLegisAPI
{

    public class Program
    {

        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //        .MinimumLevel.Debug()
            //        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //        .Enrich.FromLogContext()
            //    // Add this line:
            //    .WriteTo.File(
            //        @"D:\home\LogFiles\Application\myapp.txt",
            //    fileSizeLimitBytes: 1_000_000,
            //    rollOnFileSizeLimit: true,
            //    shared: true,
            //    flushToDiskInterval: TimeSpan.FromSeconds(1))
            //    .WriteTo.Email(
            //        fromEmail: "app@example.com",
            //        toEmail: "support@example.com",
            //        mailServer: "smtp.example.com")
            //.CreateLogger();

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();


            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                            .UseStartup<Startup>()
                            .UseIISIntegration()
                            .UseSerilog()
                            .Build();
        }
    }

}
