using Ituran.Framework.Comum.HttpClient;
using Ituran.Modulo.WorkerService.Dominio.Enum;
using Newtonsoft.Json;
using System;

namespace Ituran.Modulo.WorkerService.Dominio.Models
{
    public class Comunicacao
    {
        public NotificacaoRetorno CriarSMS()
        {
            int cdPessoa = 0;
            string mensagem = "Ituran:  voy a realizar pruebas | 1 minuto: " + DateTime.Now;
            string tracking = "";
            string numero = "11991164957";
            int cdComunicacao = 40;


            NotificacaoEnvio notificacaoEnvio = new NotificacaoEnvio
            {
                CdPessoa = cdPessoa,
                CdComunicacao = cdComunicacao,
                NrTipoAcao = 0,
                CdSistema = 11,
                Mensagem = mensagem,
                TipoComunicacaoEnum = TipoComunicacaoEnum.SMS,
                SMSDados = new SMSDados
                {
                    Numero = numero,
                    CodigoRastreio = tracking
                }

            };
            return EnviarComunicacao(notificacaoEnvio);
        }

        private NotificacaoRetorno EnviarComunicacao(NotificacaoEnvio notificacao)
        {
            try
            {

                using (RestfulClient<dynamic> restClient = new RestfulClient<dynamic>("http://localhost:1001/", "/v1/Comunicacao/EnviarComunicacao/"))
                {
                    dynamic result = restClient.Save(notificacao);

                    if (result.Data is null)
                        throw new Exception();

                    NotificacaoRetorno notificacaoResponse = JsonConvert.DeserializeObject<NotificacaoRetorno>(result.Data.ToString());

                    if (notificacaoResponse.ComunicacaoEnviada == false)
                        throw new Exception();

                    return notificacaoResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
