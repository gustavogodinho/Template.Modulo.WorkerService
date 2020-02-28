using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ituran.Modulo.WorkerService.Dominio.Models;
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
        private readonly JsonSerializerOptions _jsonOptions;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _settings = new WorkerSettings();
            new ConfigureFromConfigurationOptions<WorkerSettings>(configuration.GetSection("WorkerSettings")).Configure(_settings);
           
            _jsonOptions = new JsonSerializerOptions()
            {
                IgnoreNullValues = true
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("Verificando eventos: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                PessoaComunicacao _pessoaComunicacao = new PessoaComunicacao();

                NotificacaoRetorno notificacao = _pessoaComunicacao.CriarSMS();

                string jsonResultado = JsonSerializer.Serialize(notificacao, _jsonOptions);

                if (notificacao.DsErroRetornado != null)
                {
                    _logger.LogInformation(jsonResultado);
                }
                else
                {
                    _logger.LogInformation(jsonResultado);
                }

                await Task.Delay(_settings.DelayMilliseconds, stoppingToken);
            }

          
        }
    }
}
