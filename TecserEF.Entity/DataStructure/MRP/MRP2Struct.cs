using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure.MRP
{
    public class MRP2Struct
    {
        public string MaterialMP { get; set; } 
        public decimal CantRequired { get; set; } 
        public decimal StockTotal { get; set; } //Stock Liberado
        public decimal StockReservado { get; set; } //Stock Reserva
        public decimal StockDispProd { get; set; } //Stock Disponible Produccion
        public DateTime FechaHora { get; set; }
    }
}
