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
    
    public partial class T0213_OP_FACT
    {
        public int IDOP { get; set; }
        public int IDITEM { get; set; }
        public int PROVEEDOR { get; set; }
        public string MON_OP { get; set; }
        public Nullable<decimal> TC { get; set; }
        public Nullable<int> FACT_ID { get; set; }
        public string FACT_NUM { get; set; }
        public string FACT_MON { get; set; }
        public Nullable<decimal> FACT_SALDO_O { get; set; }
        public Nullable<decimal> FACT_SALDO_IMPUTAR { get; set; }
        public Nullable<decimal> FACT_IMPUTADO { get; set; }
        public string FACT_TIPO { get; set; }
        public bool CK_FIN { get; set; }
        public Nullable<int> NASIENTO { get; set; }
        public Nullable<decimal> RetencionIIBB { get; set; }
        public Nullable<decimal> RetencionGS { get; set; }
        public Nullable<int> IdFacturaX { get; set; }
        public Nullable<int> IdCtaCte { get; set; }
    
        public virtual T0210_OP_H T0210_OP_H { get; set; }
    }
}