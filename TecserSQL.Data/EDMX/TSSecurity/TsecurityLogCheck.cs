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
    
    public partial class TsecurityLogCheck
    {
        public int idMsg { get; set; }
        public string Tcode { get; set; }
        public string RoleCheck { get; set; }
        public string Username { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool AccessGranted { get; set; }
        public string Equipo { get; set; }
        public string IP { get; set; }
        public string Mensaje { get; set; }
    }
}