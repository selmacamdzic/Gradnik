using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulSefGradilista.Models;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulReferent.Controllers
{
    [Autorizacija(KorisnikUloga.Referent)]
    public class NarudzbaController : Controller
    {
        // GET: ModulReferent/Narudzba

        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            return View();
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
                Stavke = ctx.NarudbzbaStavka.Where(x => x.NarudzbaId == Id)
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
                BrojFakture = DateTime.UtcNow.Date + "-" + RandomString(3),
                DobavljacId = obj.DobavljacId,
                Iznos = iznos,
                SkladisteId = obj.SkladisteId,
                NarudzbaId = narudzba.Id,
                DatumKreiranja = DateTime.Now
            };

            ctx.Ulaz.Add(ulazNarudzbe);
            narudzba.NarudzbaStatus = NarudzbaStatus.Procesirana;
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

            ctx.SaveChanges();

            return RedirectToAction("Procesirane");
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}