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
    
    public partial class T0202_CTACTESALDOS
    {
        public int IDCLIENTE { get; set; }
        public string CUENTATIPO { get; set; }
        public Nullable<decimal> DEUDA_USD { get; set; }
        public Nullable<decimal> DEUDA_ARS { get; set; }
        public Nullable<decimal> DEUDA_TOT_ARS { get; set; }
        public Nullable<decimal> TC { get; set; }
        public Nullable<decimal> LCREDITO { get; set; }
        public Nullable<int> NDIAS { get; set; }
        public string NUFACTN { get; set; }
        public string NMON { get; set; }
        public Nullable<decimal> NSALDO { get; set; }
        public Nullable<System.DateTime> UFACT { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public string LogUsuario { get; set; }
        public Nullable<System.DateTime> UPAGO { get; set; }
        public Nullable<bool> FACTPEND { get; set; }
    
        public virtual T0006_MCLIENTES T0006_MCLIENTES { get; set; }
    }
}