﻿using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulReferent.Controllers
{
    [Autorizacija(KorisnikUloga.Referent)]
    public class IzlazneFaktureController : Controller
    {
        // GET: ModulReferent/IzlazneFakture
        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            var model = ctx.Izlaz.ToList();

            return View(model);
        }

        public ActionResult Detalji(int id)
        {
            var model = ctx.IzlazStavke.Where(x => x.IzlazId == id).ToList();
            return View(model);
        }
    }
}