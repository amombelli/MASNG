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
    
    public partial class T0009_MATERIALSPEC
    {
        public string IdMaterial { get; set; }
        public byte[] Foto1 { get; set; }
        public byte[] Foto2 { get; set; }
        public Nullable<decimal> CIEL { get; set; }
        public Nullable<decimal> CIEA { get; set; }
        public Nullable<decimal> CIEB { get; set; }
        public Nullable<decimal> ColourIndex { get; set; }
        public string CASNumber { get; set; }
        public string Pantone { get; set; }
        public string RAL { get; set; }
    
        public virtual T0010_MATERIALES T0010_MATERIALES { get; set; }
    }
}
