using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulDirektor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulDirektor.Controllers
{
    public class ProjektiController : Controller
    {
        // GET: ModulDirektor/Projekti
        MojContext ctx = new MojContext();

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

        public ActionResult Dodaj()
        {
            var model = new ProjektiAddVM
            {
                Korisnik = ctx.Korisnici.Select(x => new SelectListItem
                {
                    Text = x.Ime + " " + x.Prezime,
                    Value = x.Id.ToString()
                }).ToList(),

                Investitor = ctx.Investitori.Select(x => new SelectListItem
                {
                    Text = x.Naziv + "-" + x.ImeOdgovorneOsobe,
                    Value = x.Id.ToString()
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Dodaj(ProjektiAddVM obj)
        {

            var projekatAdd = new Projekti
            {
                InvestitorId = obj.InvestitorId,
                KorisnikId = obj.KorisnikId,
                DatumUgovora = obj.Projekat.DatumUgovora,
                KrajProjekta = obj.Projekat.KrajProjekta,
                PocetakProjekta = obj.Projekat.PocetakProjekta,
                Status = ProjektStatus.Aktivan
            };

            ctx.Projekti.Add(projekatAdd);
            ctx.SaveChanges();

            var gradilisteAdd = new Gradiliste
            {
                Adresa = obj.Gradiliste.Adresa,
                ProjektiId = projekatAdd.Id,
                Grad = obj.Gradiliste.Grad,
                Opstina = obj.Gradiliste.Opstina,
                PostanskiBroj = obj.Gradiliste.PostanskiBroj
            };

            ctx.Gradiliste.Add(gradilisteAdd);

            ctx.SaveChanges();

            return RedirectToAction("Aktivni");
        }

        public ActionResult Aktivni()
        {
            var model = ctx.Projekti
                .Where(x => x.Status == ProjektStatus.Aktivan)
                .ToList();

            return View(model);
        }
    }
}
