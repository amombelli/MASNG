//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TecserEF.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class T0032_RECURSOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0032_RECURSOS()
        {
            this.T0042_PRODUCCION_DET = new HashSet<T0042_PRODUCCION_DET>();
        }
    
        public int IdRecurso { get; set; }
        public string NombreRecurso { get; set; }
        public string DescRecurso { get; set; }
        public string PLTN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0042_PRODUCCION_DET> T0042_PRODUCCION_DET { get; set; }
    }
}
