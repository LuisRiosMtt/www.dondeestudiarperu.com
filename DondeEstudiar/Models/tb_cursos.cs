//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DondeEstudiar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_cursos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_cursos()
        {
            this.tb_carreras = new HashSet<tb_carreras>();
        }
    
        public int id_curso { get; set; }
        public string nom_curso { get; set; }
        public Nullable<bool> estado { get; set; }
        public System.DateTime fec_reg { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_carreras> tb_carreras { get; set; }
    }
}
