using Ituran.Modulo.WorkerService.Data.Context;
using Ituran.Modulo.WorkerService.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Ituran.Modulo.WorkerService.Data.Models
{
    public class AlertaSeguranca
    {
        private readonly WorkerContext _workerContext;
        
        public AlertaSeguranca(WorkerContext workerContext)
        {
            _workerContext = workerContext;
        }

        public string VerificaAlerta()
        {
            DateTime DT_ALERTA_INICIO = DateTime.Now;
            double tempoAlerta = 60000;

            // 1 Consultar tabela (retorno Lista)
            var listaDeAlertas = ConsultarAlerta();

            // 2 Verifica se retornou alguma linha
            if (listaDeAlertas.Length > 0)
            {
                //Loop da lista 
                // 3   Verifica se a data inicio esta expirada
                bool t = DT_ALERTA_INICIO.AddMilliseconds(tempoAlerta) >= DateTime.Now;

                // Se sim
                if (t)
                {

                    var alerta = _workerContext.ALERTA_SEGURANCA_DADOS.Add();
                    
                       
                    // ALERTA_ATIVO = 0
                    // DT_ALERTA_FIM = DateTime
                    // DESATIVACAO_MANUAL = Automatico
                    // Pega a ultima localização e atualiza (LATITUDE_FIM, LONGITUDE_FIM)
                    // Envia Alerta para Lista de contatos (DS_CONTATOS)
                    EnviarAlerta("lista de telefones");
                }
            }
            

            return "";
        }
        public async Task<List<ALERTA_SEGURANCA>> FindAllAsync()
        {
            return await _workerContext.ALERTA_SEGURANCA.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<ALERTA_SEGURANCA>> FindAllAsync()
        {
            return await _workerContext.ALERTA_SEGURANCA.ToListAsync();
        }

        private List<ALERTA_SEGURANCA> ConsultarAlerta()
        {
            var r = _workerContext.ALERTA_SEGURANCA.Where(x => x.ALERTA_ATIVO == 1).ToList();

            var q = from a in _workerContext.ALERTA_SEGURANCA
                    join b in _workerContext.ALERTA_SEGURANCA_DADOS on a equals b.CD_ALERTA_SEGURANCA
                    select new { a.ALERTA_TEMPO, b.DT_ALERTA_INICIO };

            return r;
        }

        private void EnviarAlerta(string dscontatos)
        {
            //DS_CONTATOS lista
            //Link da ultima localização (LastLocation)

            try
            {
                Comunicacao _pessoaComunicacao = new Comunicacao();
                //NotificacaoRetorno notificacao = _pessoaComunicacao.CriarSMS();
                _pessoaComunicacao.CriarSMS();

            }
            catch (Exception)
            {

            }
        }

        public async Task SaveAsync(ALERTA_SEGURANCA_DADOS seller)
        {
            _workerContext.Add(seller);
            await _workerContext.SaveChangesAsync();
        }

    }
}
