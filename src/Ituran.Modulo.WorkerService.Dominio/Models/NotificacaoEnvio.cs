using Ituran.Modulo.WorkerService.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ituran.Modulo.WorkerService.Dominio.Models
{
    public class NotificacaoEnvio
    {
        public int CdPessoa { get; set; }
        public int CdComunicacao { get; set; }
        public int CdSistema { get; set; }
        public int NrTipoAcao { get; set; }
        public string Mensagem { get; set; }
        public TipoComunicacaoEnum TipoComunicacaoEnum { get; set; }
        public EmailDados EmailDados { get; set; }
        public SMSDados SMSDados { get; set; }
        public PushNotificationDados PushNotificationDados { get; set; }
    }

    public class EmailDados
    {
        public string[] Para { get; set; }
        public string Assunto { get; set; }
        public List<Anexo> Anexos { get; set; }
    }

    public class Anexo
    {
        public string Nome { get; set; }
        public byte[] Conteudo { get; set; }
    }

    public class SMSDados
    {
        public string Numero { get; set; }
        public string CodigoRastreio { get; set; }
    }

    public class PushNotificationDados
    {
        public string[] PlayerIds { get; set; }
        public string Segmento { get; set; }
        public TipoEnvioNotificacaoEnum TipoEnvioNotificacaoEnum { get; set; }
    }
}
