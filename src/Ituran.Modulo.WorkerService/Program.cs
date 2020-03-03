using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ituran.Modulo.WorkerService.Data;
using Ituran.Modulo.WorkerService.Data.Models;

namespace Ituran.Modulo.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddDbContext(hostContext.Configuration);
                    
                    RegisterServices(services);
                });

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IAlertaSeguranca>();
            // services.AddScoped<IAlertaSeguranca>();
        }

    }
}
