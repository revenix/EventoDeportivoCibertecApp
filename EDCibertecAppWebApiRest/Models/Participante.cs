using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDCibertecAppWebApiRest.Models
{
    public class Participante
    {
        public int id_participante { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string sexo { get; set; }
        public string valoracion { get; set; }
        public string nombre { get; set; }
        
    }

    public class Participantelista
    {
        public string nombre { get; set; }
        public string puesto { get; set; }
        public int id_participante { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string valoracion { get; set; }

    }

}