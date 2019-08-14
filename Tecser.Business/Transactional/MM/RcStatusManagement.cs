using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class RcStatusManagement
    {
        public enum Status
        {
            Inicial,
            Cancelado,
            Aprobado,
            RCGenerada,
            OCGenerada
        }
        public static Status MapTextToStatus(string status)
        {
            if (String.IsNullOrEmpty(status))
                return Status.Inicial;
            try
            {
                return (Status)Enum.Parse(typeof(Status), status, true);
            }
            catch (Exception)
            {
                return Status.Inicial;
                throw;
            }
        }

        public void SetCancelado(int idRc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == idRc);
                d.StatusRc = Status.Cancelado.ToString();
                d.AproboOC = null;
                d.FechaAproboOC = null;
                db.SaveChanges();
            }
        }

        public void SetRCAprobada(int idRc,string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == idRc);
                d.StatusRc = Status.Aprobado.ToString();
                d.AproboOC = GlobalApp.AppUsername;
                d.FechaAproboOC = DateTime.Now;
                d.CometarioOC = comentario;
                db.SaveChanges();
            }
        }

        public void SetOCGenerada(int idRc, int numeroOC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == idRc);
                d.StatusRc = Status.OCGenerada.ToString();
                d.NumeroOC = numeroOC;
                db.SaveChanges();

            }
        }

    }
}
