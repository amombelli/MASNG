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
    
    public partial class TAUX_G2
    {
        public int IDCLI { get; set; }
        public int IDR { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string CONTACTO { get; set; }
        public string MENSAJE { get; set; }
        public Nullable<System.DateTime> LLAMARN { get; set; }
        public bool PAGOLISTO { get; set; }
        public string LOG_USER { get; set; }
        public Nullable<System.DateTime> LOG_DATE { get; set; }
        public Nullable<System.DateTime> PAGOLISTADATE { get; set; }
    }
}
