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
    
    public partial class USR999
    {
        public int ID { get; set; }
        public Nullable<int> IDCLI { get; set; }
        public bool LAST { get; set; }
        public bool BLKCD { get; set; }
        public string BLKCDMOTIVO { get; set; }
        public string BLKCDUSER { get; set; }
        public bool BLKNP { get; set; }
        public string BLKNPMOTIVO { get; set; }
        public string BLKNPUSER { get; set; }
        public string LOGUSER { get; set; }
        public Nullable<System.DateTime> LOGDATE { get; set; }
        public Nullable<System.DateTime> BLKNPDATE { get; set; }
        public Nullable<System.DateTime> BLKCDDATE { get; set; }
    }
}