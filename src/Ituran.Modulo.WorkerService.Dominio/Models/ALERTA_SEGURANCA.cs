using System;
using System.Collections.Generic;
using System.Text;

namespace Ituran.Modulo.WorkerService.Dominio.Models
{
    public class ALERTA_SEGURANCA
    {
        public int CD_ALERTA_SEGURANCA { get; set; }
        public string NM_ALERTA_SEGURANCA { get; set; }
        public int CD_PESSOA { get; set; }
        public int ALERTA_TEMPO { get; set; }
        public DateTime DT_CRIACAO { get; set; }
        public int ALERTA_ATIVO { get; set; }
        public string DS_MENSAGEM { get; set; }
        public string[] DS_CONTATOS { get; set; }

    }
}
