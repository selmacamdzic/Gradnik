using Gradnik_Data;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulDirektor.Controllers
{

    [Autorizacija(false, true)]
    public class HomeController : Controller
    {
        // GET: Direktor/Home

        MojContext ctx = new MojContext();
        public ActionResult Prikaz()
        {
            var model = ctx.Dobavljaci.ToList();
            return View(model);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}