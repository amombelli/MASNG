using System;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class CustomerNcdAjustes
    {
        public int GrabaT300HeaderData(T0300_NCD_H header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == header.IDH);
                if (data==null)
                {
                    header.TEMP = false;
                    header.IDH = db.T0300_NCD_H.Max(c => c.IDH) + 1;
                    header.NDOC = GetMaxDocument(ManageDocumentType.TipoDocumento.AjusteSaldoPositivo, header.TIPO);
                    header.LOGUSER = Environment.UserName;
                    header.LOGDATE = DateTime.Now;
                    db.T0300_NCD_H.Add(header);
                    db.SaveChanges();
                    return header.IDH;
                }
                else
                {
                    //var data = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == header.IDH);
                    header.LOGUSER = Environment.UserName;
                    header.LOGDATE = DateTime.Now;
                    db.Entry(data).CurrentValues.SetValues(header);
                    db.SaveChanges();
                    return header.IDH;
                }
            }
        }

        public void UpdateNCDHAfterConta(int idh, int numeroAsiento, int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idh);
                data.ASIENTO = numeroAsiento;
                data.idCtaCte = idCtaCte;
                db.SaveChanges();
            }
        }

        public int AddNcdItem(int idH,string item, string moneda,decimal importe,string gl)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataHeader = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idH);
                string descripcion;
                if (item == "AJCONTA")
                {
                    descripcion = "Ajuste Contable de Saldos A/R";
                }
                else
                {
                    //buscar la descripcion de tabla T0010?
                    descripcion = null;
                }
                var data = new T0301_NCD_I()
                {
                    IDH = idH,
                    CANT = 1,
                    IDITEM = 1,
                    IVA21 = false,
                    TDOC = dataHeader.TDOC,
                    NDOC = dataHeader.NDOC,
                    DESC = descripcion,
                    ITEM = "AJCONTA",
                    MON = moneda,
                    PUNITARIO = importe,
                    PTOTAL = importe,
                    GL = gl
                };
                db.T0301_NCD_I.Add(data);
                return db.SaveChanges();
            }
        }

        private string GetMaxDocument(ManageDocumentType.TipoDocumento tdoc, string tipoLx)
        {
            var tipoD = ManageDocumentType.GetSystemDocumentType(tdoc);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var y = db.T0300_NCD_H.Where(c => c.TDOC == tipoD && c.TIPO==tipoLx).OrderByDescending(c => c.IDH).ToList();
                if (y.Any() == false)
                {
                    return tipoLx == "L1" ? "0091-00000001" : "0092-00000001";
                }
                else
                {
                    var x = y[0].NDOC;
                    string pre;
                    if (tipoLx == "L1")
                    {
                        pre = "0091";
                    }
                    else
                    {
                        pre = "0092";
                    }

                    //var pre = x.Substring(0, 4);
                    var num = x.Substring(x.Length - 8);
                    var numX = Convert.ToInt32(num) + 1;
                    return pre+"-"+numX.ToString("00000000");
                }
            }
        }

    }
}
