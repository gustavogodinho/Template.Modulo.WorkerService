using System;
using System.Collections.Generic;
using System.Text;

namespace Ituran.Modulo.WorkerService.Dominio.Models
{
    public class ALERTA_SEGURANCA_DADOS
    {
        public int CD_ALERTA_SEGURANCA_DADOS { get; set; }
        public ALERTA_SEGURANCA CD_ALERTA_SEGURANCA { get; set; }
        public DateTime DT_ALERTA_INICIO { get; set; }
        public DateTime DT_ALERTA_FIM { get; set; }
        public string LATITUDE_INICIO { get; set; }
        public string LONGITUDE_INICIO { get; set; }
        public string LATITUDE_FIM { get; set; }
        public string LONGITUDE_FIM { get; set; }
        public int DESATIVACAO_MANUAL { get; set; }
    }
}
