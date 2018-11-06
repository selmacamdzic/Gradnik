using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulSefGradilista.Models;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    public class GradilisteController : Controller
    {
        // GET: ModulSefGradilista/Gradiliste

        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            var korisnik = Autentifikacija.GetLogiraniKorisnik(this.HttpContext);
            var model = ctx.Gradiliste.Where(g=>g.Projekti.KorisnikId == korisnik.Id)
                .ToList();
            return View(model);
        }

        public ActionResult UtrosakMaterijala(int id)
        {
            var model = new AddIzlazVM
            {
                Materijal = ctx.Materijali
                                .Select(x => new SelectListItem
                                {
                                    Text = x.Naziv,
                                    Value = x.Id.ToString()
                                })
                                .ToList(),
                Skladiste = ctx.Skladista
                                .Select(x => new SelectListItem
                                {
                                    Text = x.Naziv,
                                    Value = x.Id.ToString()
                                })
                                .ToList(),
                GradilisteId = id,
                Kolicina = 1
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UtrosakMaterijala(AddIzlazVM obj)
        {
            var izlaz = new Izlaz
            {
                DatumKreiranja = DateTime.Now,
                GradilisteId = obj.GradilisteId,
                SkladisteId = obj.SkladisteId
            };

            ctx.Izlaz.Add(izlaz);
            ctx.SaveChanges();

            var izlazStavka = new IzlazStavke
            {
                MaterijalId = obj.MaterijalId,
                IzlazId = izlaz.Id,
                Kolicina = obj.Kolicina,
            };

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ListaIzvjestaja(int id)
        {
            ViewBag.GradilisteId = id;
            return View(id);
        }

        public ActionResult _Spremljeni(int id)
        {
            var model = ctx.Izvjestaji.Where(i => i.GradilisteId == id).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult SpremiIzvjestaj(EvidencijaGradilistaVM obj)
        {
            var izvjestaj = new Izvjestaji
            {
                GradilisteId = obj.GradilisteId,
                Izvjestaj = obj.Izvjestaj,
                Datum = DateTime.UtcNow
            };
            ctx.Izvjestaji.Add(izvjestaj);
            ctx.SaveChanges();

            return RedirectToAction("_Spremljeni", new { id = obj.GradilisteId });
        }

        [HttpPost]
        public ActionResult ObrisiIzvjestaj(int id)
        {
            var izvjestaj = ctx.Izvjestaji.FirstOrDefault(x => x.Id == id);
            var gradilisteId = izvjestaj.GradilisteId;
            ctx.Izvjestaji.Remove(izvjestaj);
            ctx.SaveChanges();

            return RedirectToAction("_Spremljeni", new { id = gradilisteId });
        }
    }
}