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
    
    public partial class T0155_SALDOS
    {
        public string IDCUENTA { get; set; }
        public string MONEDA { get; set; }
        public Nullable<decimal> SALDO { get; set; }
        public Nullable<System.DateTime> UMOV { get; set; }
    
        public virtual T0150_CUENTAS T0150_CUENTAS { get; set; }
        public virtual T0150_CUENTAS T0150_CUENTAS1 { get; set; }
    }
}