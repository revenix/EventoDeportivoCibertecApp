//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDCibertecAppWebApiRest
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_equipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_equipo()
        {
            this.tb_detalle_participante = new HashSet<tb_detalle_participante>();
            this.tb_ficha_inscripcion = new HashSet<tb_ficha_inscripcion>();
        }
    
        public int id_equipo { get; set; }
        public string nombre { get; set; }
        public System.DateTime fec_reg { get; set; }
        public string color_uniforme { get; set; }
        public string estado { get; set; }
        public byte[] foto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_detalle_participante> tb_detalle_participante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ficha_inscripcion> tb_ficha_inscripcion { get; set; }
    }
}
