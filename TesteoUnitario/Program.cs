using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using MASng.MasterData;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;


namespace TesteoUnitario
{
    class Program
    {
        static void Main(string[] args)
        {


            var asiento = new AsientoContableManager(new TecserData());
            asiento.CreaHeaderMemoria(Convert.ToDateTime("23/05/2017"),"L1","FA","0010-00538662");
            asiento.GrabaHeaderDB(asiento.H);

            //new AsientoContableManager().LoadAsientoInMemory(44000);
           

            string dateTime = "01/08/2017 14:50:50.42";  
            DateTime dt = Convert.ToDateTime(dateTime);



            new OrdenPagoManageDatos().SetNewOP(dt, "L1", 10);
            
            
            // var z = new ListOfControls(this, true, false, false, false, true, true).GetListOfControls();

            //var pf = new MrpManager().AddMrpAuto("CNE008I", 1000, DateTime.Today.AddDays(4), null, "CERR");
            
            //var stk1 = new StockManager().GetStockByMaterial("MPPVCGR");
            //Console.WriteLine(stk1);

            //var stk = new StockManager().GetTotalStockByMaterial_ByEstado("MPPVCGR");
            
            //foreach (var x in stk)
            //{
            //    Console.WriteLine(x.Primario);
            //    Console.WriteLine(x.TotalKg.ToString());
            //}



            //var so = new SalesOrderManager();
            //var z = so.LoadSalesOrderInMemory(25778);
            //Console.WriteLine(so.GetListSalesOrderByCustomer(25778).Count);
            //Console.WriteLine(so.GetListSalesOrderByCustomer(384));
            //var add = new AddressManager();
            //Console.WriteLine(add.GetIdProvincia("ME{NDOZA"));
            //Console.WriteLine(add.GetIdPartido(1,"la matanza"));
            //Console.WriteLine(add.GetIdLocalidad(65, "lomas del Mirador "));
            Console.ReadKey();

            //var x = new CustomerManager();
            //Console.WriteLine(x.GetId6FromCustomerT7(494));
            //x.Prueba(77);
        }
    }
}
