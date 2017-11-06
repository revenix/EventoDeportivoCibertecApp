using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDCibertecAppWebApiRest.Models
{
    public class Evento
    {
        public int idevento { get; set; }
        public string nombre_evento { get; set; }
        public string lugar { get; set; }
        public string fecha_inicio { get; set; }
        
    }
}