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
    
    public partial class T0035_CostRoll
    {
        public string Material { get; set; }
        public string MType { get; set; }
        public Nullable<int> FCost { get; set; }
        public string MonedaCosto { get; set; }
        public Nullable<System.Guid> CostRollId { get; set; }
        public decimal CostoUnitarioRepo { get; set; }
        public decimal CostoUnitarioStd { get; set; }
        public decimal CostoUnitarioPPP { get; set; }
        public System.DateTime RecordAddedOn { get; set; }
        public string RecordAddedBy { get; set; }
        public System.DateTime CostRollDate { get; set; }
        public bool ManualUpdated { get; set; }
        public Nullable<System.DateTime> CostRepoDate { get; set; }
        public Nullable<System.DateTime> CostStdDate { get; set; }
        public Nullable<System.DateTime> CostPppDate { get; set; }
        public string MOrigen { get; set; }
        public Nullable<int> MaterialComplex { get; set; }
    
        public virtual T0034_CostRollHeader T0034_CostRollHeader { get; set; }
        public virtual T0010_MATERIALES T0010_MATERIALES { get; set; }
    }
}