using System.Collections.Generic;
using System.Linq;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;using Tecser.Business.MainApp;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.SD
{
    public class CDListManager
    {

        private List<CDStructure> _cd = new List<CDStructure>();


//Parcial
//Cancelado
//INICIAL
//Despachado
//NULL
//CERRADO_M
//Pendiente


        public List<CDStructure> GetListPendientesDespacho()
        {
            var listaResultado = new List<CDStructure>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var y =
                    db.T0046_OV_ITEM.Where(
                        c =>
                            c.StatusItem.ToUpper().Equals("PARCIAL") || c.StatusItem.ToUpper().Equals("INICIAL") ||
                            c.StatusItem.ToUpper().Equals("PENDIENTE") &&
                            (c.T0045_OV_HEADER.StatusOV.ToUpper().Equals("PROCESO") &&
                             !c.T0045_OV_HEADER.StatusOV.ToUpper().Equals("INICIAL")));


                foreach (var ix in y)
                {
                    var item = new CDStructure();
                    item.Aka = ix.Material;
                    item.Primario = ix.materialPrimario;
                    item.FantasiaC7 = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.ClienteEntregaDesc;
                    item.RazonSocialC7 = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial;
                    item.IdC6 = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.IDCLIENTE;
                    item.IdC7 = ix.T0045_OV_HEADER.CLIENTE.Value;
                    item.FechaCompromiso = ix.T0045_OV_HEADER.FechaEntrega.Value;
                    item.IdOv = ix.T0045_OV_HEADER.IDOV;
                    item.StatusOv = ix.T0045_OV_HEADER.StatusOV;
                    item.StatusItem = ix.StatusItem;
                    item.KgPedidos = ix.Cantidad;
                    item.KgDespachados = ix.KGStockDespachados.Value;
                    item.KgPendientes = (ix.Cantidad - (decimal) ix.KGStockDespachados);
                    item.KgComprometidos = ix.KGStockComprometido.Value;
                    item.KgStockTotal = StockList.GetKgStockTotalByMaterial(item.Primario, "CERR");
                    item.DireccionEntrega = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.Direccion_Entrega;
                    item.LocalidadEntrega = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.DireEntre_Localidad;
                    item.ZonaEntrega = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.DireEntre_Zona;
                    item.LX = ix.MODO;
                    item.IdItem = ix.IDITEM;
                    listaResultado.Add(item);
                }
                return listaResultado;
            }
        }

        public List<CDStructure> GetListPendientesDespachoCliente(int id6, bool withStock = true)
        {
            var listaResultado = new List<CDStructure>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var y =
                    db.T0046_OV_ITEM.Where(
                        c => c.T0045_OV_HEADER.T0007_CLI_ENTREGA.IDCLIENTE == id6 && (
                            c.StatusItem.ToUpper()
                                .Equals(SalesOrderStatusManager.StatusItem.Inicial.ToString().ToUpper()) ||
                            c.StatusItem.ToUpper()
                                .Equals(SalesOrderStatusManager.StatusItem.Parcial.ToString().ToUpper()) ||
                            c.StatusItem.ToUpper()
                                .Equals(SalesOrderStatusManager.StatusItem.Pendiente.ToString().ToUpper()))).ToList();

                foreach (var ix in y)
                {
                    var item = new CDStructure();
                    item.Aka = ix.Material;
                    item.Primario = ix.materialPrimario;
                    item.FantasiaC7 = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.ClienteEntregaDesc;
                    item.RazonSocialC7 = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial;
                    item.IdC6 = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.IDCLIENTE;
                    item.IdC7 = ix.T0045_OV_HEADER.CLIENTE.Value;
  //                if (ix.T0045_OV_HEADER.FechaEntrega != null)
                    item.FechaCompromiso = ix.FechaCompromiso;
                    item.IdOv = ix.T0045_OV_HEADER.IDOV;
                    item.StatusOv = ix.T0045_OV_HEADER.StatusOV;
                    item.StatusItem = ix.StatusItem;
                    item.KgPedidos = ix.Cantidad;
                    item.KgDespachados = ix.KGStockDespachados.Value;
                    item.KgPendientes = (ix.Cantidad - (decimal)ix.KGStockDespachados);
                    item.KgComprometidos = ix.KGStockComprometido.Value;
                    item.KgStockTotal = StockList.GetKgStockTotalByMaterial(item.Primario, "CERR");
                    item.DireccionEntrega = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.Direccion_Entrega;
                    item.LocalidadEntrega = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.DireEntre_Localidad;
                    item.ZonaEntrega = ix.T0045_OV_HEADER.T0007_CLI_ENTREGA.DireEntre_Zona;
                    item.LX = ix.MODO;
                    item.IdItem = ix.IDITEM;
                    listaResultado.Add(item);
                }
                return listaResultado;
            }
        }
    }
}
