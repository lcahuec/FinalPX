//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenP10.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UBICACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UBICACION()
        {
            this.CLIENTE = new HashSet<CLIENTE>();
        }
    
        public int Id { get; set; }
        public int Continente { get; set; }
        public int Pais { get; set; }
        public int Ciudad { get; set; }
    
        public virtual CIUDAD CIUDAD1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }
        public virtual CONTINENTE CONTINENTE1 { get; set; }
        public virtual PAIS PAIS1 { get; set; }
    }
}
