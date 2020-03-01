using Ituran.Modulo.WorkerService.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ituran.Modulo.WorkerService.Data.Models
{
    public class AlertaSeguranca
    {
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
                    // ALERTA_ATIVO = 0
                    // DT_ALERTA_FIM = DateTime
                    // DESATIVACAO_MANUAL = Automatico 
                    // Envia Alerta para Lista de contatos (DS_CONTATOS)
                    EnviarAlerta("lista de telefones");
                }

            }
            
            return "";
        }


        private string ConsultarAlerta()
        {
            //Consulta no banco
            // ALERTA_ATIVO = 1 Ativo
            return "";
        }

        private void EnviarAlerta(string dscontatos)
        {
            //DS_CONTATOS lista


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




    }
}
