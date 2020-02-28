using Ituran.Modulo.WorkerService.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ituran.Modulo.WorkerService.Dominio.Models
{
   public class NotificacaoRetorno
    {

        public bool ComunicacaoEnviada { get; set; }
        public TipoComunicacaoEnum TipoComunicacaoEnum { get; set; }
        public string DsErroRetornado { get; set; }
    }
}
