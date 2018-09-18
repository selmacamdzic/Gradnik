using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulSefGradilista.Models;
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
                Datum = DateTime.Now,
                KorisnikId = 3, //TO-DO remove
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

        public ActionResult AktivneNarudzbe()
        {
            var aktivneNarudzbe = ctx.Narudzbe
                .Where(x => x.NarudzbaStatus == NarudzbaStatus.Aktivna)
                .ToList();

            return View(aktivneNarudzbe);
        }

        public ActionResult Detalji(int Id)
        {
            var aktivneNarudzbe = ctx.Narudzbe
                .Where(x => x.Id == Id)
                .FirstOrDefault();

            var dobavljaci = ctx.Dobavljaci
                .ToList();

            var narudzbaDetalji = new NarudzbaDetaljiViewModel
            {
                Id = aktivneNarudzbe.Id,
                Stavke = ctx.NarudbzbaStavka.Where(x => x.Id == Id)
                            .Select(x => new NarudzbaStavkeViewModel
                            {
                                Kolicina = x.Kolicina,
                                MaterijalId = x.Materijal.Id,
                                Naziv = x.Materijal.Naziv
                            })
                            .ToList(),
                Dobavljaci = ctx.Dobavljaci.Select(x => new SelectListItem
                {
                    Text = x.Naziv + "-" + x.Adresa,
                    Value = x.Id.ToString()
                }).ToList(),

                Skladiste = ctx.Skladista.Select(x => new SelectListItem
                {
                    Text = x.Naziv + "-" + x.Lokacija,
                    Value = x.Id.ToString()
                }).ToList()
            };

            return View(narudzbaDetalji);
        }

        public ActionResult Procesiraj(NarudzbaProcesirajViewModel obj)
        {
            var narudzba = ctx.Narudzbe
                .Where(x => x.Id == obj.NarudzbaId)
                .FirstOrDefault();

            decimal iznos = 0;
            obj.Stavke.ForEach(x => iznos = +x.Kolicina * x.Cijena);
            var ulazNarudzbe = new Ulaz
            {
                BrojFakture = obj.BrojFakture,
                DobavljacId = obj.DobavljacId,
                Iznos = iznos,
                SkladisteId = obj.SkladisteId,
                NarudzbaId = narudzba.Id,
                DatumKreiranja = DateTime.Now
            };

            ctx.Ulaz.Add(ulazNarudzbe);
            ctx.SaveChanges();

            foreach (var materijali in obj.Stavke)
            {
                var ulazStavka = new UlazStavka
                {
                    Kolicina = materijali.Kolicina,
                    MaterijalId = materijali.MaterijalId,
                    UlazId = ulazNarudzbe.Id,
                    Cijena = materijali.Cijena
                };

                ctx.UlazStavka.Add(ulazStavka);
            }

            narudzba.NarudzbaStatus = NarudzbaStatus.Procesirana;
            ctx.SaveChanges();

            return RedirectToAction("Procesirane");
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