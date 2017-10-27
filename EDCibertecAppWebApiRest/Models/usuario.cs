using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDCibertecAppWebApiRest.Models
{
    public class usuario
    {

        public int idUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int idRol { get; set; }
    }
}