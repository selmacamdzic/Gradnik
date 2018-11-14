using Gradnik_Data;
using Gradnik_Web.Areas.ModulReferent.Models;
using Gradnik_Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulReferent.Controllers
{
    public class RaspodjelaPoslaController : Controller
    {
        MojContext ctx = new MojContext();


        public ActionResult Index()
        {
            var model = new EvidencijaRadnogVremena
            {
                Od = DateTime.UtcNow.AddMonths(-1),
                Do = DateTime.UtcNow,
                Gradilista = ctx.Gradiliste.Select(x => new SelectListItem
                {
                    Text = x.Adresa + "-" + x.Grad,
                    Value = x.Id.ToString()
                }).ToList(),
                EvidencijaIsplate = new List<EvidencijaIsplateDto>()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(EvidencijaRadnogVremena obj)
        {
            var SqlParameters = new[]
            {
               new SqlParameter("Id", SqlDbType.Int) { Value = obj.GradilisteId },
               new SqlParameter("Od", SqlDbType.DateTime) { Value = obj.Od },
               new SqlParameter("Do", SqlDbType.DateTime) { Value = obj.Do }
            };

            var query = ctx.Database.SqlQuery<EvidencijaIsplateDto>("SELECT * FROM EvidencijaRadnogVremena")
                                        .ToList();
            var model = new EvidencijaRadnogVremena
            {
                Od = obj.Od,
                Do = obj.Do,
                Gradilista = ctx.Gradiliste.Select(x => new SelectListItem
                {
                    Text = x.Adresa + "-" + x.Grad,
                    Value = x.Id.ToString()
                }).ToList(),
                EvidencijaIsplate = query
            };

            return View(model);
        }

        public ActionResult Isplati(int id)
        {
            var sati = ctx.Sati.FirstOrDefault(x => x.Id == id);
            sati.isPlaceno = true;

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}