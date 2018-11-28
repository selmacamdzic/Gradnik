using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulAdmin.Models;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulAdmin.Controllers
{
    [Autorizacija(KorisnikUloga.Admin)]
    public class KorisniciController : Controller
    {
        // GET: ModulAdmin/Korisnici
        MojContext ctx = new MojContext();
        public ActionResult Index()
        {
            var model = ctx.Korisnici.ToList();
            return View(model);
        }


        public ActionResult Details(int id)
        {
            var model = ctx.Korisnici.Find(id);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Korisnici k = ctx.Korisnici.Where(x => x.Id == id).FirstOrDefault();
            ctx.Korisnici.Remove(k);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Dodaj()
        {
            var model = new KorisniciDodajVM
            {
                listaPozicija = BindPozicije(),
                DatumRodjenja = DateTime.UtcNow
            };

            return View(model);
        }

        public ActionResult Uredi(int id)
        {
            Korisnici k = ctx.Korisnici.Find(id);
            var model = new KorisniciDodajVM
            {
                KorisnikId = k.Id,
                KorisnickoIme = k.KorisnickoIme,
                Email = k.Email,
                Ime = k.Ime,
                Prezime = k.Prezime,
                DatumRodjenja = k.DatumRodjenja,
                StrucnoZanimanje = k.StrucnoZanimanje,
                Adresa = k.Adresa,
                KontaktTelefon = k.KontaktTelefon,
                listaPozicija = BindPozicije()
            };

            return View(model);
        }

        public ActionResult Spremi(KorisniciDodajVM vm)
        {
            if (!ModelState.IsValid && vm.KorisnikId == 0)
            {
                return View("Dodaj", vm);
            }
            Korisnici k;
            if (vm.KorisnikId == 0)
            {
                k = new Korisnici();
                ctx.Korisnici.Add(k);
                k.Lozinka = vm.Lozinka;

            }
            else
            {
                k = ctx.Korisnici.Find(vm.KorisnikId);
            }

            k.KorisnickoIme = vm.KorisnickoIme;
            k.Email = vm.Email;
            k.Ime = vm.Ime;
            k.Prezime = vm.Prezime;
            k.DatumRodjenja = vm.DatumRodjenja;
            k.StrucnoZanimanje = vm.StrucnoZanimanje;
            k.Adresa = vm.Adresa;
            k.KontaktTelefon = vm.KontaktTelefon;
            k.KorisnikUloga = (KorisnikUloga)vm.KorisnikPozicijaId;

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> BindPozicije()
        {
            return new List<SelectListItem>() {
                new SelectListItem
                {
                    Text = "Admin",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "Direktor",
                    Value = "2"
                },
                 new SelectListItem
                {
                    Text = "Sef Gradilista",
                    Value = "3"
                },
                  new SelectListItem
                {
                    Text = "Arhitekta",
                    Value = "4"
                },
                   new SelectListItem
                {
                    Text = "Referent",
                    Value = "5"
                }
            };
        }
    }
}