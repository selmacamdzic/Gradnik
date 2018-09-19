using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    public class HomeController : Controller
    {
        // GET: ModulSefGradilista/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}