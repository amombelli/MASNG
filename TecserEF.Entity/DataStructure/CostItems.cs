using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    public class CostItems
    {
        public string MaterialF { get; set; }
        public string ItemMP { get; set; }
        public string Moneda { get; set; }
        public decimal CostoUnit { get; set; }
        public decimal Prop { get; set; }
        public decimal CostoProp { get; set; }
    }

    public class CostHeader
    {
        public string Origen;
        public int? Fcost;
        public string Moneda;
        public decimal Costo;
        public string Material { get; set; }
        public bool CalculoOk { get; set; }
    }
}
