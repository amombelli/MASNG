using System;
using System.Linq;
using TecserEF.Entity;using Tecser.Business.MainApp;

namespace Tecser.Business.Transactional.SD
{
    public class SalesOrderStatusManager
    {
        public enum StatusHeader
        {
            Inicial,
            Emitida,
            Cerrada,
            Cancelada,
            Proceso,
        };
        public enum StatusItem
        {
            Inicial,
            Pendiente,
            Parcial,
            Despachado,
            CerradoM,
            Cancelado
        };
        public static StatusItem MapStatusItemFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = StatusItem.Pendiente.ToString();

            try
            {
                return (StatusItem) Enum.Parse(typeof(StatusItem), status, true);
            }
            catch (Exception)
            {
                return StatusItem.Inicial;
                throw;
            }
        }
        public static StatusHeader MapStatusHeaderFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = StatusHeader.Inicial.ToString();

            try
            {
                return (StatusHeader)Enum.Parse(typeof(StatusHeader), status, true);
            }
            catch (Exception)
            {
                return StatusHeader.Inicial;
                throw;
            }
        }
        public static void UpdateStatusHeaderFromStatusItem(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSO);
                var i = db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).ToList();
                var cantItems = i.Count;

                var xPendiente = 0;
                var xParcial = 0;
                var xDespachado = 0;
                var xCerradoM = 0;
                var xCancelado = 0;

                foreach (var item in i)
                {
                    var estadoItem = MapStatusItemFromText(item.StatusItem);
                    switch (estadoItem)
                    {
                        case StatusItem.Inicial:
                            break;
                        case StatusItem.Pendiente:
                            xPendiente++;
                            break;
                        case StatusItem.Parcial:
                            xParcial++;
                            break;
                        case StatusItem.Despachado:
                            xDespachado++;
                            break;
                        case StatusItem.CerradoM:
                            xCerradoM++;
                            break;
                        case StatusItem.Cancelado:
                            xCancelado++;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                if ((xPendiente + xCancelado) == cantItems)
                {
                    h.StatusOV = StatusHeader.Emitida.ToString(); //Estado Inicial
                }
                else if ((xDespachado + xCerradoM + xCancelado) == cantItems)
                {
                    h.StatusOV = StatusHeader.Cerrada.ToString();
                }
                else if (xCancelado == cantItems)
                {
                    h.StatusOV = StatusHeader.Cancelada.ToString();
                }
                else
                {
                    h.StatusOV = StatusHeader.Proceso.ToString();
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Actualiza automaticamente el estado del item (PARCIAL.DESPACHADO.PENDIENTE)
        /// </summary>
        public static void UpdateStatusItem(int idSO, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lineaSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);

                if (lineaSO == null)
                    return;

                if (lineaSO.KGStockDespachados == null)
                    lineaSO.KGStockDespachados = 0;
                
                var kgPendientesDespacho = lineaSO.Cantidad - lineaSO.KGStockDespachados.Value;

                var statusActual = MapStatusItemFromText(lineaSO.StatusItem);

                if (statusActual == StatusItem.Cancelado || statusActual == StatusItem.CerradoM)
                    return;

                if (kgPendientesDespacho <= 0)
                {
                    lineaSO.StatusItem = StatusItem.Despachado.ToString();
                }
                else
                {
                    if (lineaSO.KGStockDespachados > 0)
                    {
                        lineaSO.StatusItem = StatusItem.Parcial.ToString();
                    }
                    else
                    {
                        lineaSO.StatusItem = StatusItem.Pendiente.ToString();
                    }
                }
                db.SaveChanges();
            }
        }
        public static bool SetStatusItemCerradoM(int idSO, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (data == null)
                    return false;

                data.StatusItem = StatusItem.CerradoM.ToString();
                return db.SaveChanges() > 0;
            }
        }
        public static bool SetStatusItemCancelado(int idSO, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (data == null)
                    return false;

                data.StatusItem = StatusItem.Cancelado.ToString();
                return db.SaveChanges() > 0;
            }
        }
        public static bool SetStatusSalesOrderCancelado(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSO);
                if (h == null)
                    return false;
                var i = db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).ToList();
                foreach (var item in i)
                {
                    item.StatusItem = SalesOrderStatusManager.StatusItem.Cancelado.ToString();
                }
                h.StatusOV = SalesOrderStatusManager.StatusHeader.Cancelada.ToString();
                return db.SaveChanges()>0;
            }
        }
        



        //FUNCIONES VIEJAS PARA ABAJO

        public static void UpdateStatusHeader(int idSO)
        {
            ///esta funcion no va mas!
            int cantidadItems = 0;
            int inicial = 0;
            int pendiente = 0;
            int parcial = 0;
            int despachado = 0;
            int cerradoM = 0;
            int cancelado = 0;
            int itemsComprometidos = 0;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSO);
                var items = db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).ToList();
                foreach (var item in items)
                {
                    cantidadItems++;

                    if (item.KGStockComprometido > 0)
                    {
                        itemsComprometidos++;
                    }

                    switch (item.StatusItem.ToUpper())
                    {
                        case "INICIAL":
                            inicial++;
                            break;
                        case "PENDIENTE":
                            pendiente++;
                            break;
                        case "PARCIAL":
                            parcial++;
                            break;
                        case "DESPACHADO":
                            despachado++;
                            break;
                        case "CERRADO_M":
                            cerradoM++;
                            break;
                        case "CANCELADO":
                            cancelado++;
                            break;
                        default:
                            cancelado++;
                            break;
                    }
                }

                if (cancelado == cantidadItems)
                {
                    header.StatusOV = "Cancelado";
                    db.SaveChanges();
                    return;
                }

                if ((despachado + cerradoM + cancelado) == cantidadItems)
                {
                    header.StatusOV = "Cerrada";
                    db.SaveChanges();
                    return;
                }

                if (parcial > 0)
                {
                    header.StatusOV = "Proceso";
                    db.SaveChanges();
                    return;
                }

                if (inicial == cantidadItems)
                {
                    if (itemsComprometidos > 0)
                    {
                        header.StatusOV = "Emitida";
                        db.SaveChanges();
                        return;
                    }
                    else
                    {
                        header.StatusOV = "Inicial";
                        db.SaveChanges();
                        return;
                    }
                }
            }
        }
    }
}
