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
    
    public partial class T0055_REMITO_H
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0055_REMITO_H()
        {
            this.T0056_REMITO_I = new HashSet<T0056_REMITO_I>();
            this.T0059_ENTREGAS = new HashSet<T0059_ENTREGAS>();
            this.T0059_HOJARUTA_I = new HashSet<T0059_HOJARUTA_I>();
        }
    
        public int IDREMITO { get; set; }
        public string NUMREMITO { get; set; }
        public string TIPO_REMITO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<int> CODCLIENTREGA { get; set; }
        public Nullable<int> IDOV { get; set; }
        public string StatusRemito { get; set; }
        public Nullable<bool> Impreso { get; set; }
        public string FacturaMoneda { get; set; }
        public Nullable<int> Factura { get; set; }
        public string UserLog { get; set; }
        public Nullable<System.DateTime> FechaLog { get; set; }
        public string DESPACHADO { get; set; }
        public Nullable<int> RLINK { get; set; }
        public Nullable<decimal> TC { get; set; }
        public Nullable<bool> ZDET { get; set; }
        public string COM_PREP { get; set; }
        public Nullable<bool> FACTPEND { get; set; }
        public string PLTN { get; set; }
        public Nullable<decimal> VALOR_DEC { get; set; }
        public string OBSERVACION_REM { get; set; }
        public Nullable<int> IDFLETE { get; set; }
        public string NUMFACTURA { get; set; }
        public string PREPAREDBY { get; set; }
        public Nullable<int> CANTBULTOS { get; set; }
        public string SLOC { get; set; }
    
        public virtual T0007_CLI_ENTREGA T0007_CLI_ENTREGA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0056_REMITO_I> T0056_REMITO_I { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0059_ENTREGAS> T0059_ENTREGAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0059_HOJARUTA_I> T0059_HOJARUTA_I { get; set; }
    }
}