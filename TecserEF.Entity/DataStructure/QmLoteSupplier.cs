using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecserEF.Entity.DataStructure.SD_CRM;

namespace TecserEF.Entity.DataStructure
{
    public class QmLoteSupplierStruct
    {
        public int Id40 { get; set; }
        public DateTime FechaMov { get; set; }
        public string Material { get; set; }
        public string Lote { get; set; }
        public string Supplier { get; set; }
        public string StatusIn { get; set; }
        public int Id2 { get; set; }
        public decimal Kg { get; set; }
    }
}
