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
    
    public partial class XREGISTER_H
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XREGISTER_H()
        {
            this.XREGISTER_I = new HashSet<XREGISTER_I>();
        }
    
        public int IDINT { get; set; }
        public string REFNUM { get; set; }
        public string TIPO { get; set; }
        public string CUENTAD { get; set; }
        public string MONEDA { get; set; }
        public Nullable<decimal> IMPORTE_TOTAL { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<int> NASIENTO { get; set; }
        public Nullable<bool> CONTABILIZADO { get; set; }
        public Nullable<System.DateTime> LOG_DATE { get; set; }
        public string LOG_USER { get; set; }
        public Nullable<decimal> TC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XREGISTER_I> XREGISTER_I { get; set; }
    }
}
