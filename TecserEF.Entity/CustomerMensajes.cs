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
    
    public partial class CustomerMensajes
    {
        public int idCliente { get; set; }
        public string Mensaje { get; set; }
        public string LogUser { get; set; }
        public System.DateTime LogDate { get; set; }
        public bool VerNotaPedido { get; set; }
        public bool VerCuentaCorriente { get; set; }
        public bool VerGesco { get; set; }
        public bool VerCRM { get; set; }
        public bool VerRemito { get; set; }
        public bool VerFactura { get; set; }
        public bool Activo { get; set; }
        public string LogUserDesactivo { get; set; }
        public System.DateTime LogDateDesactivo { get; set; }
        public string MensajeDesactivado { get; set; }
    }
}
