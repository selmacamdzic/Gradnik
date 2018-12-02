using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulDirektor.Models;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulDirektor.Controllers
{
    [Autorizacija(KorisnikUloga.Direktor)]
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
                }).ToList(),
                Projekat = new Projekti
                {
                    DatumUgovora = DateTime.UtcNow,
                    PocetakProjekta = DateTime.UtcNow,
                    KrajProjekta = DateTime.UtcNow.AddMonths(1)
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Dodaj(ProjektiAddVM obj)
        {

            var projekatAdd = new Projekti
            {
                Naziv = obj.Projekat.Naziv,
                Lokacija = obj.Gradiliste.Grad,
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
                .ToList();

            return View(model);
        }

        public ActionResult Uredi(int id)
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
                }).ToList(),
                Projekat = ctx.Projekti.FirstOrDefault(x=>x.Id == id)
            };
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Uredi(ProjektiAddVM vm)
        {
            if (!ModelState.IsValid )
            {
                return View("Uredi", vm);
            }

            var projekat = ctx.Projekti.Find(vm.Projekat.Id);

            projekat.DatumUgovora = vm.Projekat.DatumUgovora;
            projekat.InvestitorId = vm.Projekat.InvestitorId;
            projekat.KorisnikId = vm.Projekat.KorisnikId;
            projekat.KrajProjekta = vm.Projekat.KrajProjekta;
            projekat.Lokacija = vm.Projekat.Lokacija;
            projekat.Naziv = vm.Projekat.Naziv;
            projekat.PocetakProjekta = vm.Projekat.PocetakProjekta;

            return RedirectToAction("Aktivni");
        }

        public ActionResult Detalji(int id)
        {
            var projekatDetlji = new ProjekatDetaljiVM
            {
                Projekat = ctx.Projekti.FirstOrDefault(p => p.Id == id),
                Radnici = ctx.RaspodjelaPosla
                                .Where(r => r.Gradiliste.ProjektiId == id && r.KrajRada == null)
                                .Select(d => new ProjekatRadniciVM
                                {
                                    Ime = d.Radnik.Ime,
                                    Prezime = d.Radnik.Prezime,
                                    JMBG = d.Radnik.JMBG,
                                    TipPosla = d.TipPosla.Naziv,
                                    RadnikId = d.RadnikId,
                                    Zvanje = d.Radnik.Zvanje
                                }).ToList()
            };

            return View(projekatDetlji);
        }
       
        public ActionResult _ListaDokumenata(int id)
        {
            var lista = ctx.Dokumentacija.Where(x => x.ProjekatId == id).ToList();

            return View(lista);
        }

        [HttpGet]
        public FileResult DownLoadFile(int id)
        {
            var file = ctx.Dokumentacija.FirstOrDefault(x => x.Id == id);
            var mimeType = MimeMapping.GetMimeMapping(file.Naziv);
            return File(file.File, mimeType, file.Naziv);

        }

        [HttpGet]
        public ActionResult Realizovan(int id)
        {
            var projekat = ctx.Projekti.FirstOrDefault(x => x.Id == id);
            projekat.Status = ProjektStatus.Realizovan;

            ctx.SaveChanges();
            return RedirectToAction("Aktivni");
        }
    }
}
