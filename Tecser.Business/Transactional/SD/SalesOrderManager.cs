using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;
using GlobalApp = Tecser.Business.MainApp.GlobalApp;

namespace Tecser.Business.Transactional.SD
{
    public class SalesOrderManager
    {
        public SalesOrderManager()
        {
            
        }

        // desde aca es nuevo para remito






        //esto es viejo hay que revisarlo!

        //public IList GetListSalesOrderByCustomer(int idCustomerT6)
        //{
        //    //return new SalesOrderDataManager(new TecserData(GlobalApp.CnnApp)).ListSalesOrderbyClienteT6(idCustomerT6);
        //}


        public IList<T0046_OV_ITEM> ListaSalesOrderDetailByCustomer(int idCustomerT6)
        {
            return
                new Repository<T0046_OV_ITEM>(new TecserData(GlobalApp.CnnApp)).GetAll()
                    .Where(c => c.ClienteRZ == idCustomerT6)
                    .OrderByDescending(c => c.IDOV).ToList();
        }


        public string GetCustomerFantasiaFromOrdenVenta(int ordenVenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == ordenVenta)
                        .T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_fantasia;
            }
        }


        //public SalesOrder LoadSalesOrderInMemory(int numeroSo)
        //{
        //    return new SalesOrderDataManager(new TecserData(GlobalApp.CnnApp)).GetCompleteSalesOrder(numeroSo);
        //}

        public bool SaveSalesOrder()
        {
            return true;
        }
    
    }
}
