using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulAdmin.Controllers
{
    [Autorizacija(KorisnikUloga.Admin)]
    public class HomeController : Controller
    {
        // GET: ModulAdmin/Home
        public ActionResult Index()
        {
            return View();
        }

        MojContext ctx = new MojContext();
        public ActionResult Prikaz()
        {
            var model = ctx.Dobavljaci.ToList();
            return View("Index", model);
        }
    }
}