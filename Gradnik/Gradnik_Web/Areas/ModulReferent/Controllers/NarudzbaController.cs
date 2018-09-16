using Gradnik_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulReferent.Controllers
{
    public class NarudzbaController : Controller
    {
        // GET: ModulReferent/Narudzba

        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}