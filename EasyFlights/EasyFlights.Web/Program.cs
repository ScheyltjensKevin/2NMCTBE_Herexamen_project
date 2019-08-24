using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace EasyFlights.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            CreateWebHostBuilder(args)
                .ConfigureLogging((hostingContext,logging)=>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                    logging.SetMinimumLevel(LogLevel.Warning)
                    .AddFilter("Default",LogLevel.Warning)
                    .AddFilter(DbLoggerCategory.Database.Command.Name,LogLevel.Information)
                    .AddFilter<ConsoleLoggerProvider>("UserController",LogLevel.Critical)
                    .AddFilter<ConsoleLoggerProvider>("TicketController", LogLevel.Critical)
                    .AddFilter<ConsoleLoggerProvider>("HomeController", LogLevel.Critical)
                    .AddFilter<ConsoleLoggerProvider>("SearchController", LogLevel.Critical);
                })
                .Build().Run();

    
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
    }
}
