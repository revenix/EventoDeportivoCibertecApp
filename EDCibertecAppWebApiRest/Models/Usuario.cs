using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDCibertecAppWebApiRest.Models
{
    public class Usuario
    {
        [Key]
        public int idusuario { get; set; }
        [Required]
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public int idrol { get; set; }

    }
}