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
    
    public partial class T0028_SLOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T0028_SLOC()
        {
            this.T0030_STOCK = new HashSet<T0030_STOCK>();
        }
    
        public string SLOC { get; set; }
        public string SLOC_DESC { get; set; }
        public bool ACTIVO { get; set; }
        public bool AllowProduction { get; set; }
        public bool AllowDelivery { get; set; }
        public bool AllowPurchase { get; set; }
        public Nullable<int> SequenceProduction { get; set; }
        public Nullable<int> SequenceDelivery { get; set; }
        public Nullable<int> SequencePurchase { get; set; }
        public string PLTN { get; set; }
    
        public virtual T0016_PLANTAS T0016_PLANTAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T0030_STOCK> T0030_STOCK { get; set; }
    }
}
