using Gradnik_Data;
using Gradnik_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulEngineering.Controllers
{
    public class ProjektiController : Controller
    {
        // GET: ModulEngineering/Projekti
        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            var model = ctx.Projekti.Where(x => x.Status == ProjektStatus.Aktivan).ToList();

            return View(model);
        }

        public ActionResult Pregled(int id)
        {
            var model = ctx.Projekti.Find(id);

            return View(model);
        }
        public ActionResult Realizovani()
        {
            var model = ctx.Projekti.Where(x => x.Status == ProjektStatus.Realizovan).ToList();

            return View(model);
        }
    }
}