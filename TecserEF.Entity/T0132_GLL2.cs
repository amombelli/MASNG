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
    
    public partial class T0132_GLL2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0132_GLL2()
        {
            this.T0133_GLL3 = new HashSet<T0133_GLL3>();
        }
    
        public int IDL2 { get; set; }
        public int IDL1 { get; set; }
        public int IDL0 { get; set; }
        public string IDC { get; set; }
        public string CUENTA_D { get; set; }
        public Nullable<bool> ACTIVO { get; set; }
        public string DOCUMENTACION { get; set; }
        public string IDC2 { get; set; }
        public Nullable<bool> PI { get; set; }
    
        public virtual T0131_GLL1 T0131_GLL1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0133_GLL3> T0133_GLL3 { get; set; }
    }
}