using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulSefGradilista.Models;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    public class NarudzbeController : Controller
    {
        MojContext ctx = new MojContext();

        // GET: ModulSefGradilista/Narudzbe
        public ActionResult Index()
        {
            var narudzbaAdd = new NarudbaListViewModel
            {
                Materijali = ctx.Materijali.ToList()
            };
            return View(narudzbaAdd);
        }

        [HttpPost]
        public ActionResult Dodaj(List<NarudbaAddViewModel> obj)
        {
            var narudzba = new Narudzba
            {
                Datum = DateTime.UtcNow,
                KorisnikId = Autentifikacija.GetLogiraniKorisnik(this.HttpContext).Id, //TO-DO remove
                NarudzbaStatus = NarudzbaStatus.Aktivna
            };

            ctx.Narudzbe.Add(narudzba);
            ctx.SaveChanges();

            foreach (var materijal in obj)
            {
                var narudzbaStavka = new NarudbzbaStavka
                {
                    NarudzbaId = narudzba.Id,
                    Kolicina = materijal.Kolicina,
                    MaterijalId = materijal.Id
                };

                ctx.NarudbzbaStavka.Add(narudzbaStavka);
            }

            ctx.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }

        

        public ActionResult Procesirane()
        {
            var procesiraneNarudzbe = ctx.Narudzbe
               .Where(x => x.NarudzbaStatus == NarudzbaStatus.Procesirana)
               .ToList();

            return View(procesiraneNarudzbe);
        }
    }
}