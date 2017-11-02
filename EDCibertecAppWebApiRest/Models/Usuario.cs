using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDCibertecAppWebApiRest.Models
{
    public class Usuario
    {
       
        public int idusuario { get; set; }
        public string login { get; set; }
        public string contraseña { get; set; }
        public int idrol { get; set; }

    }
}