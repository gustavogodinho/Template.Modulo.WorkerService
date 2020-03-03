using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ituran.Modulo.WorkerService.Data.Models;
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
        private readonly IAlertaSeguranca _alertaSeguranca; 

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IAlertaSeguranca alertaSeguranca)
        {
            _alertaSeguranca = alertaSeguranca;
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

            //Testar erros 
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Verificando eventos: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                    //Aqui consultar tabela de Alerta 
                   // var _alertaSeguranca = new AlertaSeguranca();
                    var alerta = _alertaSeguranca.VerificaAlerta();


                    Comunicacao _pessoaComunicacao = new Comunicacao();

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
            catch (Exception)
            {
                           
            }
            
        }
    }
}
