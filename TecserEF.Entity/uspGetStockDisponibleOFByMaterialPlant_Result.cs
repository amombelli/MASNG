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
    
    public partial class uspGetStockDisponibleOFByMaterialPlant_Result
    {
        public string Material { get; set; }
        public string Batch { get; set; }
        public Nullable<decimal> TotalKG { get; set; }
        public string Estado { get; set; }
        public string SLOC { get; set; }
        public Nullable<int> SequenceProduction { get; set; }
        public string PLTN { get; set; }
        public bool AllowProduction { get; set; }
        public bool AvailableStateForIP { get; set; }
    }
}