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
    
    public partial class tb_participante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_participante()
        {
            this.tb_detalle_participante = new HashSet<tb_detalle_participante>();
            this.tb_usuario = new HashSet<tb_usuario>();
        }
    
        public int id_participante { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public System.DateTime fec_nacimiento { get; set; }
        public string sexo { get; set; }
        public byte[] foto { get; set; }
        public string estado { get; set; }
        public string valoracion { get; set; }
        public int idClub { get; set; }
    
        public virtual tb_Club tb_Club { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_detalle_participante> tb_detalle_participante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario { get; set; }
    }
}
