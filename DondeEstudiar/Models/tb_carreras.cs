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
    
    public partial class tb_carreras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_carreras()
        {
            this.det_sede_carrera = new HashSet<det_sede_carrera>();
            this.tb_perfil_profesional = new HashSet<tb_perfil_profesional>();
            this.tb_cursos = new HashSet<tb_cursos>();
        }
    
        public int id_carrera { get; set; }
        public string nom_carrera { get; set; }
        public int id_area { get; set; }
        public string tipo_carrera { get; set; }
        public byte duracion { get; set; }
        public Nullable<short> popularidad { get; set; }
        public Nullable<decimal> remuneracion_prom { get; set; }
        public string ruta_img { get; set; }
        public string img_carrera { get; set; }
        public bool estado { get; set; }
        public System.DateTime fec_reg { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<det_sede_carrera> det_sede_carrera { get; set; }
        public virtual tb_areas tb_areas { get; set; }
        public virtual tb_generales tb_generales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_perfil_profesional> tb_perfil_profesional { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_cursos> tb_cursos { get; set; }
    }
}
