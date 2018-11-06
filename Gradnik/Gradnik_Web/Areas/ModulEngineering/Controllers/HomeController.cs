using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulEngineering.Controllers
{
    public class HomeController : Controller
    {
        // GET: ModulEngineering/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}