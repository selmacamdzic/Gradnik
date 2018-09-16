using Gradnik_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    public class RadniciController : Controller
    {
        // GET: ModulSefGradilista/Radnici

        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            var model = ctx.Radnici.ToList();
            return View(model);
        }


        public ActionResult Profile(int id)
        {
            var model = ctx.Radnici.Find(id);

            return View(model);

        }
    }
}