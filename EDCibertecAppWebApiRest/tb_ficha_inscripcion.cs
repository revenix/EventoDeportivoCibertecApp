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
    
    public partial class tb_ficha_inscripcion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_ficha_inscripcion()
        {
            this.tb_comprobante_pago = new HashSet<tb_comprobante_pago>();
        }
    
        public int num_ficha { get; set; }
        public System.DateTime fecha { get; set; }
        public int id_evento { get; set; }
        public int id_modalidad { get; set; }
        public int id_equipo { get; set; }
        public string estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_comprobante_pago> tb_comprobante_pago { get; set; }
        public virtual tb_detalle_modalidad tb_detalle_modalidad { get; set; }
        public virtual tb_equipo tb_equipo { get; set; }
    }
}
