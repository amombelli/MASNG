using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class RcManagement
    {
        public T0068RequisicionCompra GetRequisicion(int idRc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == idRc);
            }
        }

        public List<T0068RequisicionCompra> GetAllRc()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0068RequisicionCompra.OrderByDescending(c => c.idRc).ToList();
            }
        }

        public int CreateNewRc(string material, decimal? kgConteo, decimal kgRequisicion,string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int idRc = 1;
                if (db.T0068RequisicionCompra.Any())
                {
                    idRc = db.T0068RequisicionCompra.Max(c => c.idRc)+1;
                }

                var data = new T0068RequisicionCompra
                {
                    idRc = idRc,
                    ComentarioRc = comentario,
                    FechaRc = DateTime.Now,
                    KgRequeridos = kgRequisicion,
                    KgStockRevisado = kgConteo,
                    Material = material,
                    StatusRc = RcStatusManagement.Status.RCGenerada.ToString(),
                    UserRc = GlobalApp.AppUsername,
                };
                db.T0068RequisicionCompra.Add(data);
                if (db.SaveChanges()>0) return idRc;
                return 0;

            }
        }

    }
}
