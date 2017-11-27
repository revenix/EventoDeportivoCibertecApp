using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCibertecAppWebApiRest.Models
{
   public class Usuario
    {
        public int id_participante { get; set; }

        public string nombres { get; set; }
        
        public string apellidos { get; set; }
        
        public int id_perfil { get; set; }
        
        public string descripcion { get; set; }
    }
   
}
