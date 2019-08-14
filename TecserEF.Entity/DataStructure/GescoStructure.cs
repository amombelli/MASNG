using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    /// <summary>
    /// Estructura utilizada para GESCO02
    /// </summary>
    public class GescoStructure
    {
        public string ClienteRs { get; set; }
        public string ClienteFantasia { get; set; }
        public int IdCliente { get; set; }
        public decimal SaldoL1 { get; set; }
        public decimal SaldoL2 { get; set; }
        public decimal SaldoTotal { get; set; }
        public decimal? LimiteCredito { get; set; }
        public int DocumentosImpagos { get; set; }
        public bool ConciliarCtaRequest { get; set; }
        public bool CallRequest { get; set; }
        public DateTime? ProximaLlamada { get; set; }
    }
}
