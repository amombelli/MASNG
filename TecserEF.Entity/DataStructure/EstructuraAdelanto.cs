﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    public partial class EstructuraAdelanto
    {
        public int Id { get; set; }
        public string EmpleadoShort { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Comentario { get; set; }
        public string CompromisoPago { get; set; }
        public string Concepto { get; set; }
        public decimal ImporteSolicitado { get; set; }
    }
}
