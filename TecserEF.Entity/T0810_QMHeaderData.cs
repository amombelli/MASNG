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
    
    public partial class T0810_QMHeaderData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0810_QMHeaderData()
        {
            this.T0811_QMDetailData = new HashSet<T0811_QMDetailData>();
        }
    
        public int IDI { get; set; }
        public string MATERIAL { get; set; }
        public string LOTE { get; set; }
        public Nullable<decimal> KG { get; set; }
        public string Origen { get; set; }
        public Nullable<int> IdOrigen { get; set; }
        public string NombreProv { get; set; }
        public string COMENTARIO { get; set; }
        public string EstadoMaterial { get; set; }
        public string EstadoPlan { get; set; }
        public Nullable<System.DateTime> FechaINPlan { get; set; }
        public Nullable<System.DateTime> FechaStart { get; set; }
        public Nullable<System.DateTime> FechaFinish { get; set; }
        public string CQResp { get; set; }
        public Nullable<System.DateTime> LOG_DATE { get; set; }
        public string LOG_USER { get; set; }
        public string PlanName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0811_QMDetailData> T0811_QMDetailData { get; set; }
    }
}