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
    
    public partial class T0063_ITEMS_OC_INGRESADOS
    {
        public int ID { get; set; }
        public Nullable<int> PROVEEDOR { get; set; }
        public string PCUIT { get; set; }
        public string PRAZONSOCIAL { get; set; }
        public Nullable<System.DateTime> FECHA_OC { get; set; }
        public Nullable<int> NUM_OC { get; set; }
        public Nullable<System.DateTime> FECHA_IN { get; set; }
        public string IDMATERIAL { get; set; }
        public Nullable<decimal> CANTIDAD { get; set; }
        public string MON_OC { get; set; }
        public Nullable<decimal> TC { get; set; }
        public Nullable<decimal> PRECIO_U_ARS { get; set; }
        public Nullable<decimal> PRECIO_U_USD { get; set; }
        public Nullable<decimal> PRECIO_T_ARS { get; set; }
        public Nullable<decimal> PRECIO_T_USD { get; set; }
        public string NREMITO { get; set; }
        public string NFACTURA { get; set; }
        public Nullable<bool> CONTA { get; set; }
        public Nullable<decimal> CONTA_CANT { get; set; }
        public Nullable<decimal> CONTA_U_ARS { get; set; }
        public Nullable<decimal> CONTA_U_USD { get; set; }
        public Nullable<decimal> CONTA_TOTAL { get; set; }
        public Nullable<bool> ADDED { get; set; }
        public string CCOSTO { get; set; }
        public Nullable<bool> ZINCLUIR { get; set; }
        public string GL { get; set; }
        public string TIPO { get; set; }
        public Nullable<int> NASIENTO { get; set; }
        public Nullable<int> ID40 { get; set; }
        public Nullable<int> NP { get; set; }
        public Nullable<bool> REPRO { get; set; }
        public string MATERIALFAB { get; set; }
        public Nullable<decimal> KGFAB { get; set; }
        public Nullable<decimal> KGENTREGA { get; set; }
        public string STATUSNP { get; set; }
        public Nullable<System.DateTime> FechaRemitoReal { get; set; }
        public string RespControlRecepcion { get; set; }
        public int IdItemOC { get; set; }
        public string ObservacionIngreso { get; set; }
    
        public virtual T0005_MPROVEEDORES T0005_MPROVEEDORES { get; set; }
    }
}
