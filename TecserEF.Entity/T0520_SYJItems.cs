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
    
    public partial class T0520_SYJItems
    {
        public int idH { get; set; }
        public int idItem { get; set; }
        public string EmpleadoShort { get; set; }
        public string PosicionHR { get; set; }
        public string Concepto { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string LogUSer { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public string AproboUser { get; set; }
        public Nullable<System.DateTime> AproboDate { get; set; }
        public bool Aprobado { get; set; }
    
        public virtual T0519_SYJHeader T0519_SYJHeader { get; set; }
    }
}