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
    
    public partial class T0133_GLL3
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0133_GLL3()
        {
            this.T0134_GLL4 = new HashSet<T0134_GLL4>();
        }
    
        public int IDL3 { get; set; }
        public int IDL2 { get; set; }
        public int IDL1 { get; set; }
        public int IDL0 { get; set; }
        public string IDC { get; set; }
        public string CUENTA_D { get; set; }
        public Nullable<bool> ACTIVO { get; set; }
        public string DOCUMENTACION { get; set; }
        public Nullable<bool> SM { get; set; }
        public string IDC2 { get; set; }
        public Nullable<bool> PI { get; set; }
    
        public virtual T0132_GLL2 T0132_GLL2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0134_GLL4> T0134_GLL4 { get; set; }
    }
}