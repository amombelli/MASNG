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
    
    public partial class T0801_QMMasterIPHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0801_QMMasterIPHeader()
        {
            this.T0802_QMMasterIPDetail = new HashSet<T0802_QMMasterIPDetail>();
            this.T0805_QMIRecordH1 = new HashSet<T0805_QMIRecordH1>();
        }
    
        public string IDPLAN { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<bool> ACTIVO { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string LogUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0802_QMMasterIPDetail> T0802_QMMasterIPDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0805_QMIRecordH1> T0805_QMIRecordH1 { get; set; }
    }
}