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
    
    public partial class T0042_PRODUCCION_DET
    {
        public int IDMOV { get; set; }
        public string MATERIAL { get; set; }
        public Nullable<int> TIPOMOV { get; set; }
        public Nullable<int> OF { get; set; }
        public string OFS { get; set; }
        public string LOTE { get; set; }
        public Nullable<decimal> KG { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<System.DateTime> HORAI { get; set; }
        public Nullable<System.DateTime> HORAF { get; set; }
        public Nullable<int> RECURSO_PROD { get; set; }
        public Nullable<int> NUMSTOPS { get; set; }
        public Nullable<bool> LIM_CABEZAL { get; set; }
        public Nullable<bool> LIM_COMPLETA { get; set; }
        public Nullable<int> TIEMPO_STOP { get; set; }
        public string STOP_OBS { get; set; }
        public string OPERADOR { get; set; }
        public Nullable<int> NUM_PASADAS { get; set; }
        public Nullable<int> ID40 { get; set; }
    
        public virtual T0032_RECURSOS T0032_RECURSOS { get; set; }
        public virtual T0040_MAT_MOVIMIENTOS T0040_MAT_MOVIMIENTOS { get; set; }
    }
}
