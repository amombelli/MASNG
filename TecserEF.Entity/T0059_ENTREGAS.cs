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
    
    public partial class T0059_ENTREGAS
    {
        public int IdEntregas { get; set; }
        public Nullable<int> idRemito { get; set; }
        public string TipoEntrega { get; set; }
        public string StatusEntrega { get; set; }
        public Nullable<System.DateTime> FechaEntrega { get; set; }
        public string ClienteEntrega { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> IdRutaAsignada { get; set; }
        public string NumeroRemito { get; set; }
        public string ClienteRazonSocial { get; set; }
    
        public virtual T0007_CLI_ENTREGA T0007_CLI_ENTREGA { get; set; }
        public virtual T0055_REMITO_H T0055_REMITO_H { get; set; }
        public virtual T0059_HOJARUTA_H T0059_HOJARUTA_H { get; set; }
    }
}
