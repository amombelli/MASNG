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
    
    public partial class T0012_TIPO_MATERIAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0012_TIPO_MATERIAL()
        {
            this.T0010_MATERIALES = new HashSet<T0010_MATERIALES>();
            this.T0011_MATERIALES_AKA = new HashSet<T0011_MATERIALES_AKA>();
        }
    
        public string TIPO_MATERIAL { get; set; }
        public string DESCRIPCION { get; set; }
        public bool STOCK { get; set; }
        public bool DISPO_NP { get; set; }
        public bool DISPO_RE { get; set; }
        public bool DISPO_FA { get; set; }
        public bool DISPO_RE_2 { get; set; }
        public bool MM_COLOR { get; set; }
        public bool MM_BASE { get; set; }
        public bool MM_BATCH_DF { get; set; }
        public bool MM_AKA { get; set; }
        public bool DISPO_BOM { get; set; }
        public string DEF_UNIT { get; set; }
        public string DOC_GEN { get; set; }
        public bool DISPO_OF { get; set; }
        public bool DISPO_OC { get; set; }
        public string COMENTARIOS { get; set; }
        public bool DISPO_NC { get; set; }
        public bool DISPO_ND { get; set; }
        public string GL { get; set; }
        public string GLV { get; set; }
        public bool COSTO { get; set; }
        public string SLOC_DEF { get; set; }
        public decimal MGMULT { get; set; }
        public decimal MGADD { get; set; }
        public string OrigenDefault { get; set; }
        public string MaterialPrefixDefault { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0010_MATERIALES> T0010_MATERIALES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0011_MATERIALES_AKA> T0011_MATERIALES_AKA { get; set; }
    }
}
