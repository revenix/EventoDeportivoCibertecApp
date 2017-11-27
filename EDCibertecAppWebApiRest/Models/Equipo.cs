using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDCibertecAppWebApiRest.Models
{
    public class Equipo
    {
        public int num_ficha { get; set; }
        public int id_equipo { get; set; }
        public string nombre { get; set; }

    }

    public class Equipoxparticipante
    {
        public int id_equipo { get; set; }
        public string nombre { get; set; }
        public string colorUniforme { get; set; }

    }
}