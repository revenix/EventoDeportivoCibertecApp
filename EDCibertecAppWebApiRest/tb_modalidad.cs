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
    
    public partial class tb_modalidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_modalidad()
        {
            this.tb_detalle_modalidad = new HashSet<tb_detalle_modalidad>();
        }
    
        public int id_modalidad { get; set; }
        public int id_disciplina { get; set; }
        public int id_categoria { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public string estado { get; set; }
    
        public virtual tb_categoria tb_categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_detalle_modalidad> tb_detalle_modalidad { get; set; }
        public virtual tb_disciplina tb_disciplina { get; set; }
    }
}
