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
    
    public partial class T0035_COSTO_EVAL
    {
        public int ID { get; set; }
        public Nullable<int> IDCLIENTERS { get; set; }
        public Nullable<int> IDCLIENTE_2 { get; set; }
        public string RAZONSOC { get; set; }
        public string LX { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string IDMATERIAL { get; set; }
        public Nullable<decimal> CANTIDAD { get; set; }
        public Nullable<decimal> COSTOSTD { get; set; }
        public Nullable<decimal> COSTOREP { get; set; }
        public Nullable<decimal> COSTOALT { get; set; }
        public Nullable<int> IDREMITO { get; set; }
        public Nullable<decimal> COSTOOP { get; set; }
        public Nullable<decimal> PRECIOVTA { get; set; }
        public Nullable<decimal> MARGEN { get; set; }
        public Nullable<decimal> MARGEN_OP { get; set; }
        public string MONEDA { get; set; }
        public Nullable<int> ITEMREMITO { get; set; }
    }
}