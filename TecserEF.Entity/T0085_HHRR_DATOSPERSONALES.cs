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
    
    public partial class T0085_HHRR_DATOSPERSONALES
    {
        public string IDEMPLEADO { get; set; }
        public string DireccionCalle { get; set; }
        public string DireccionProvincia { get; set; }
        public string DireccionLocalidad { get; set; }
        public Nullable<System.DateTime> UltimaActualizacionDireccion { get; set; }
        public string EmailPersonal { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string DNI { get; set; }
        public string CUIL { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
    
        public virtual T0085_PERSONAL T0085_PERSONAL { get; set; }
    }
}
