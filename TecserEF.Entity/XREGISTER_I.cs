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
    
    public partial class XREGISTER_I
    {
        public int IDINT { get; set; }
        public int IDITEM { get; set; }
        public string CUENTA_O { get; set; }
        public string CUENTA_D { get; set; }
        public Nullable<bool> CH { get; set; }
        public Nullable<int> CHID { get; set; }
        public string CUENTA { get; set; }
        public string MONEDA { get; set; }
        public Nullable<decimal> IMPORTE_O { get; set; }
        public Nullable<decimal> IMPORTE_ARS { get; set; }
        public Nullable<bool> CONTABILIZADO { get; set; }
        public string GLO { get; set; }
        public string GLD { get; set; }
        public Nullable<decimal> IMPORTE_D { get; set; }
        public string CHTIPO { get; set; }
    
        public virtual XREGISTER_H XREGISTER_H { get; set; }
    }
}
