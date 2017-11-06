using System;
using System.Collections.Generic;
using System.Linq; 

namespace EventoDeportivoCibertecApp.portable
{
    public class Modalidad
    {
        public int id_modalidad { get; set; }
        public int id_disciplina { get; set; }
        public string deporte { get; set; }
        public int id_categoria { get; set; }
        public string categoria { get; set; }
        
    }
}