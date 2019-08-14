using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    public class CtaCteEstiloClienteStructure
    {
        public string ClienteRs { get; set; }
        public string ClienteFantasia { get; set; }
        public int IdCliente { get; set; }
        public string Tdoc { get; set; }
        public string NumeroDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public decimal Importe { get; set; }
        public decimal SaldoAcumulado { get; set; }
        public string Lx { get; set; }
       
    }
}
