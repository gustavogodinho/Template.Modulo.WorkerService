using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ituran.Modulo.WorkerService.Dominio.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ituran.Modulo.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly WorkerSettings _settings;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _settings = new WorkerSettings();
            new ConfigureFromConfigurationOptions<WorkerSettings>(configuration.GetSection("WorkerSettings")).Configure(_settings);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("Verificando eventos: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                await Task.Delay(_settings.DelayMilliseconds, stoppingToken);
            }

            _logger.LogInformation("Ituran.Worker Service stopping at: {time}", DateTimeOffset.Now);
        }
    }
}
