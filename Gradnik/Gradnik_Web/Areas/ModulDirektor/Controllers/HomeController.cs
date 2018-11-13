using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using Gradnik_Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulDirektor.Controllers
{
    [Autorizacija(KorisnikUloga.Direktor)]
    public class HomeController : Controller
    {
        // GET: Direktor/Home

        MojContext ctx = new MojContext();
    
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BrojRadnikaPoProjektima()
        {
            var query = ctx.Database.SqlQuery<BrojRadnikaPoProjektimaDto>("SELECT * FROM BrojRadnikaPoProjektima")
                                        .ToList();
            var dataset = new List<object>();
            foreach (var item in query)
            {
                dataset.Add(new
                {
                    name = item.Naziv,
                    data = new ArrayList { item.BrojRadnika }
                });
            }
            return Json(dataset, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProsjecnaCijenaPoMaterijalu()
        {
            var query = ctx.Database.SqlQuery<ProsjecnaCijenaMaterijalaDto>("SELECT * FROM ProsjecnaCijenaPoMaterijalu")
                                        .ToList();
            var dataset = new List<object>();
            foreach (var item in query)
            {
                dataset.Add(new
                {
                    name = item.Materijal,
                    data = new ArrayList { item.Cijena }
                });
            }
            return Json(dataset, JsonRequestBehavior.AllowGet);
        }
    }
}