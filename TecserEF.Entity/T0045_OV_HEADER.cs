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
    
    public partial class T0045_OV_HEADER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0045_OV_HEADER()
        {
            this.T0046_OV_ITEM = new HashSet<T0046_OV_ITEM>();
        }
    
        public int IDOV { get; set; }
        public Nullable<System.DateTime> FECHA_OV { get; set; }
        public Nullable<int> CLIENTE { get; set; }
        public string Vendedor { get; set; }
        public Nullable<System.DateTime> FechaEntrega { get; set; }
        public string ObservacionesOV { get; set; }
        public string StatusOV { get; set; }
        public Nullable<System.DateTime> StatusEN { get; set; }
        public string LOG_USER { get; set; }
        public Nullable<System.DateTime> LOG_FECHA { get; set; }
        public string LogChUser { get; set; }
        public Nullable<System.DateTime> LogChDate { get; set; }
        public string NumeroOC { get; set; }
        public string MetodoIngreso { get; set; }
    
        public virtual T0007_CLI_ENTREGA T0007_CLI_ENTREGA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0046_OV_ITEM> T0046_OV_ITEM { get; set; }
    }
}
