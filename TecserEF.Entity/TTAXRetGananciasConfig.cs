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
    
    public partial class TTAXRetGananciasConfig
    {
        public int ConceptoId { get; set; }
        public string Concepto { get; set; }
        public string ConceptoDescripcion { get; set; }
        public Nullable<decimal> BaseNoRetencion { get; set; }
        public Nullable<decimal> AlicRetencionInscripto { get; set; }
        public Nullable<decimal> AlicRetencionNoInscripto { get; set; }
    }
}