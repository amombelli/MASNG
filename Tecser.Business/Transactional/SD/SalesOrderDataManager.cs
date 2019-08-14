using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.SD
{
    public class SalesOrderDataManager
    {
        public int InicializaSalesOrderDb(int idClienteT7,string status)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = new T0045_OV_HEADER
                {
                    CLIENTE = idClienteT7,
                    StatusOV = status,
                    LOG_FECHA = DateTime.Now,
                    LOG_USER = Environment.UserDomainName,
                    IDOV = db.T0045_OV_HEADER.Max(c => c.IDOV) + 1,
                };
                db.T0045_OV_HEADER.Add(data);
                if (db.SaveChanges() > 0)
                    return data.IDOV;
                return 0;
            }
        }
        public bool AgregaItemSalesOrder(T0046_OV_ITEM item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                item.CK = false;
                item.CKUPD = false;
                item.AUTO_SPLIT = false;
                db.T0046_OV_ITEM.Add(item);
                return db.SaveChanges() > 0;
            }

        }
        public bool EmiteSalesOrderHeader(int idSO,DateTime fechaSalesOrder, string comentarioSalesOrder, string vendedor,string numeroOC,string metodoIngreso)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSO);
                if (h == null)
                    return false;

                h.FECHA_OV = fechaSalesOrder;
                h.ObservacionesOV = comentarioSalesOrder;
                h.Vendedor = vendedor;
                h.NumeroOC = numeroOC;
                h.MetodoIngreso = metodoIngreso;
                h.StatusOV = SalesOrderStatusManager.StatusHeader.Emitida.ToString();
                return db.SaveChanges() > 0;
            }
        }
        public bool EmiteSalesOrderItems(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).ToList();
                foreach (var item in items)
                {
                    if (item.StatusItem == SalesOrderStatusManager.StatusItem.Inicial.ToString())
                    {
                        item.StatusItem = SalesOrderStatusManager.StatusItem.Pendiente.ToString();
                        var kgFabricar = item.Cantidad - item.KGStockComprometido.Value;
                        var urgente = item.PRIORIDAD == "URGENTE";

                        if (kgFabricar > 0)
                        {
                            var mrpResult = new MrpManager().AddMrpAuto(item.Material, kgFabricar,
                                item.FechaCompromiso.Value, item.ObservacionItem, "CERR", item.IDOV, urgente);
                            item.MRPAuto = mrpResult;
                        }
                    }
                    else
                    {
                        //aca no tengo nada para hacer po el momento porque solo activo
                        //con el item en INCIAL.
                    }
                }
                db.SaveChanges();
            }
            return true;
        }
        public List<T0046_OV_ITEM> GetDataItemsFromDb(int idSo)
        {
            using (var db = new  TecserData(GlobalApp.CnnApp))
            {
                return db.T0046_OV_ITEM.Where(c => c.IDOV == idSo).ToList();
            }
        }
        public T0045_OV_HEADER GetDataHeaderFromDb(int idSo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSo);
            }
        }
        public T0046_OV_ITEM GetDataItemFromDb(int idSo, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSo && c.IDITEM == idItem);
            }
        }
        public bool UpdateItemData(T0046_OV_ITEM item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == item.IDOV && c.IDITEM == item.IDITEM);
                if (data == null)
                    return false;

                data.Cantidad = item.Cantidad;
                data.FechaCompromiso = item.FechaCompromiso;
                data.ObservacionItem = item.ObservacionItem;
                data.PRIORIDAD = item.PRIORIDAD;
                data.MODO = item.MODO;
                data.Material_Cli = item.Material_Cli;
                data.MonedaCotiz = item.MonedaCotiz;
                data.PRECIO1 = item.PRECIO1;
                data.PRECIO2 = item.PRECIO2;
                data.PrecioUnitario = item.PrecioUnitario;
                data.PRECIOTOTAL = item.PRECIOTOTAL;
                data.CK = false;
                data.CKUPD = true;
                data.AUTO_SPLIT = false;
                return db.SaveChanges() > 0;
            }
        }
    }
}
