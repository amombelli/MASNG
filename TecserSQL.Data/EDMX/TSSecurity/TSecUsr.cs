//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TecserSQL.Data.EDMX.TSSecurity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TSecUsr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TSecUsr()
        {
            this.TSecRoleAssignment = new HashSet<TSecRoleAssignment>();
        }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }
        public string Password { get; set; }
        public string ShortnameEmpleado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TSecRoleAssignment> TSecRoleAssignment { get; set; }
    }
}