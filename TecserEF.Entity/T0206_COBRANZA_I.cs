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
    
    public partial class T0206_COBRANZA_I
    {
        public int IDCOB { get; set; }
        public int LINE { get; set; }
        public string NRECIBO { get; set; }
        public string CUENTA { get; set; }
        public string MON_ITEM { get; set; }
        public Nullable<decimal> IMP_ITEM { get; set; }
        public Nullable<decimal> TC_ITEM { get; set; }
        public string MON_RECIBO { get; set; }
        public Nullable<decimal> IMP_RECIBO { get; set; }
        public string CHEQUE_NUMERO { get; set; }
        public string CHEQUE_BANCO { get; set; }
        public string CHEQUE_INTERIOR { get; set; }
        public string CHEQUE_TITULAR { get; set; }
        public string CHEQUE_CUIT { get; set; }
        public Nullable<System.DateTime> CHEQUE_FECHA { get; set; }
        public string COMENTARIO { get; set; }
        public Nullable<bool> ITEM_IMPUTADO { get; set; }
        public Nullable<bool> ITEM_TEMP { get; set; }
        public Nullable<int> IDCH { get; set; }
    
        public virtual T0150_CUENTAS T0150_CUENTAS { get; set; }
        public virtual T0205_COBRANZA_H T0205_COBRANZA_H { get; set; }
    }
}
