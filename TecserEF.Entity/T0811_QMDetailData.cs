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
    
    public partial class T0811_QMDetailData
    {
        public int IDPI { get; set; }
        public int COUNTER { get; set; }
        public string MATERIAL { get; set; }
        public string METODO { get; set; }
        public string VALORSTD { get; set; }
        public string VALORCQ { get; set; }
        public string RESULTADOCQ { get; set; }
        public Nullable<System.DateTime> FechaControl { get; set; }
        public string UserControl { get; set; }
        public bool ControlOK { get; set; }
        public string COMENTARIO { get; set; }
        public string LOG_USER { get; set; }
        public Nullable<System.DateTime> LOG_DATE { get; set; }
        public bool MetodoAdded { get; set; }
    
        public virtual T0810_QMHeaderData T0810_QMHeaderData { get; set; }
    }
}