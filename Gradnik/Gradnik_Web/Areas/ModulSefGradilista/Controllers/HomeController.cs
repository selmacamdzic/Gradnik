using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using Gradnik_Web.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    [Autorizacija(KorisnikUloga.SefGradilista)]
    public class HomeController : Controller
    {
        MojContext ctx = new MojContext();

        // GET: ModulSefGradilista/Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult PotrosnjaPoGradilistu(int id)
        {
            var SqlParameters = new[]
            {
               new SqlParameter("Id", SqlDbType.Int) { Value = id }
            };

            var query = ctx.Database.SqlQuery<PotrosnjaMaterijalaDto>("SELECT * FROM PotrosnjaMaterijalaPoGradilistu WHERE GradilisteId = @Id", SqlParameters)
                                        .ToList();
            var dataset = new List<object>();
            foreach (var item in query)
            {
                dataset.Add(new
                {
                    name = item.Materijal,
                    data = new ArrayList { item.Kolicina}
                });
            }
            return Json(dataset, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BrojRadnikaByTipPosla(int id)
        {
            var SqlParameters = new[]
            {
               new SqlParameter("Id", SqlDbType.Int) { Value = id }
            };

            var query = ctx.Database.SqlQuery<BrojRadnikaTipPoslaDto>("SELECT * FROM BrojRadnikaByTipPosla WHERE GradilisteId = @Id", SqlParameters)
                                        .ToList();
            var dataset = new List<object>();
            foreach (var item in query)
            {
                dataset.Add(new
                {
                    name = item.TipPosla,
                    y =  item.BrojRadnika 
                });
            }
            return Json(dataset, JsonRequestBehavior.AllowGet);
        }
    }
}