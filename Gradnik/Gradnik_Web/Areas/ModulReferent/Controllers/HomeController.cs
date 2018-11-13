using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using Gradnik_Web.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulReferent.Controllers
{
    [Autorizacija(KorisnikUloga.Referent)]
    public class HomeController : Controller
    {
        MojContext ctx = new MojContext();

        // GET: ModulReferent/Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Top10KoristenihMaterijala()
        {
            var query = ctx.Database.SqlQuery<TopKoristeniMaterijaliDto>("SELECT * FROM Top10KoristenihMaterijala")
                                        .ToList();
            var dataset = new List<object>();
            foreach (var item in query)
            {
                dataset.Add(new
                {
                    name = item.Materijal,
                    data = new ArrayList { item.Kolicina }
                });
            }
            return Json(dataset, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProsjecnaPotrosnjaMaterijala()
        {
            var query = ctx.Database.SqlQuery<ProsjecnaPotrosnjaMaterijalaDto>("SELECT * FROM ProsjecnaPotrosnjaMaterijala")
                                        .ToList();
            var dataset = new List<object>();
            foreach (var item in query)
            {
                dataset.Add(new
                {
                    name = item.Materijal,
                    y =  item.Kolicina
                });
            }
            return Json(dataset, JsonRequestBehavior.AllowGet);
        }
    }
}