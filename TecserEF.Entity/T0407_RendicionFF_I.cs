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
    
    public partial class T0407_RendicionFF_I
    {
        public int idRendicion { get; set; }
        public int idItem { get; set; }
        public string item { get; set; }
        public string itemDescripcion { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal precioTotal { get; set; }
        public bool aplicaIva { get; set; }
        public string glItem { get; set; }
    
        public virtual T0135_GLX_FF T0135_GLX_FF { get; set; }
        public virtual T0406_RendicionFF_H T0406_RendicionFF_H { get; set; }
    }
}
