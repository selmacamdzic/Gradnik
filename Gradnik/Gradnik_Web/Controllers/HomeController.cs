using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MojContext ctx = new MojContext();
        public ActionResult Prikaz()
        {
            var model = ctx.Dobavljaci.ToList();
            return View("Index",model);
        }




        public ActionResult Index()
        {
            Korisnici k = Autentifikacija.GetLogiraniKorisnik(HttpContext);
            if (k == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            if (k.isAdmin)
            {
                return RedirectToAction("Prikaz", "Home", new { area = "ModulAdmin" });
            }
            if (k.isDirektor)
            {
                return RedirectToAction("Prikaz", "Home", new { area = "ModulDirektor" });
            }
            if (k.isGradjevinskiIng || k.isArhitekta)
            {
                return RedirectToAction("Index", "Projekti", new { area = "ModulEngineering" });
            }
            if (k.isReferent)
            {
                return RedirectToAction("Index", "UlazneFakture", new { area = "ModulReferent" });
            }

            return RedirectToAction("Logout", "Autentifikacija", new { area = "" });
        }
    }
}