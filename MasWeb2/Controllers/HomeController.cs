using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tecser.Business.MasterData;


namespace MasWeb2.Controllers
{
    public class HomeController: Controller
    {
        public JsonResult Index()
        {

            return Json( new CustomerManager().GetCustomerBillToData(1).cli_fantasia);
        }
    }
}
