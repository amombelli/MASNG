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
    
    public partial class T0046_OV_ITEM
    {
        public Nullable<int> IDOVINT { get; set; }
        public int IDOV { get; set; }
        public int IDITEM { get; set; }
        public int ClienteRZ { get; set; }
        public string materialPrimario { get; set; }
        public string Material { get; set; }
        public string Material_Cli { get; set; }
        public decimal Cantidad { get; set; }
        public string MonedaCotiz { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> KGStockComprometido { get; set; }
        public Nullable<decimal> KGStockDespachados { get; set; }
        public string StatusItem { get; set; }
        public bool FlagStockComprometido { get; set; }
        public string MRPAuto { get; set; }
        public string MODO { get; set; }
        public Nullable<decimal> PRECIO1 { get; set; }
        public Nullable<decimal> PRECIO2 { get; set; }
        public Nullable<decimal> PRECIOTOTAL { get; set; }
        public string LOG_USER { get; set; }
        public Nullable<System.DateTime> LOG_FECHA { get; set; }
        public string OBSERVACIONES { get; set; }
        public Nullable<int> DESPACHO_NUM { get; set; }
        public Nullable<bool> AUTO_SPLIT { get; set; }
        public Nullable<System.DateTime> FechaCompromiso { get; set; }
        public Nullable<bool> CK { get; set; }
        public string ObservacionItem { get; set; }
        public Nullable<bool> CKUPD { get; set; }
        public string PRIORIDAD { get; set; }
        public Nullable<decimal> DescuentoMonedaOrigen { get; set; }
        public Nullable<decimal> DescuentoPorcentaje { get; set; }
        public string MotivoPrecioCero { get; set; }
        public string AutorizoPrecioCero { get; set; }
    
        public virtual T0045_OV_HEADER T0045_OV_HEADER { get; set; }
    }
}
