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
    [Autorizacija(true, false)]
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
            Korisnici k = ctx.Korisnici.Where(x=>x.Id==id).FirstOrDefault();
            ctx.Korisnici.Remove(k);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Dodaj()
        {
            var model = new KorisniciDodajVM
            {
                listaPozicija = BindPozicije()
            };

            return View(model);
        }

        private List<SelectListItem> BindPozicije()
        {
            return ctx.KorisnikPozicija.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();
        }

        public ActionResult Uredi(int id)
        {
            Korisnici k = ctx.Korisnici.Find(id);
            var model = new KorisniciDodajVM
            {
                KorisnikId = k.Id,
                KorisnickoIme=k.KorisnickoIme,
                Email=k.Email,
                Ime=k.Ime,
                Prezime=k.Prezime,
                DatumRodjenja=k.DatumRodjenja,
                StrucnoZanimanje=k.StrucnoZanimanje,
                Adresa=k.Adresa,
                KontaktTelefon=k.KontaktTelefon,
                KorisnikPozicijaId=k.KorisnikPozicijaId,
                listaPozicija=BindPozicije()
            };

            return View(model);
        }

        //TODO provjeriti sta sa validacijom kada je poziv iz uredi
        public ActionResult Spremi(KorisniciDodajVM vm)
        {
            if (!ModelState.IsValid && vm.KorisnikId==0)
            {
                vm.listaPozicija = BindPozicije();
                return View("Dodaj", vm);
            }


            Korisnici k;
            if (vm.KorisnikId==0)
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
            k.KorisnikPozicijaId = vm.KorisnikPozicijaId;
            KorisnikPozicija novaPozicija = ctx.KorisnikPozicija.Find(vm.KorisnikPozicijaId);

            k.isDirektor = false;
            k.isSefGradilista = false;
            k.isGradjevinskiIng = false;
            k.isArhitekta = false;
            k.isAdmin = false;

            //TODO staviti enume za fikseve
            if (novaPozicija.Naziv == "Direktor")
                k.isDirektor = true;
            if (novaPozicija.Naziv.Contains("Sef gradilista"))
                k.isSefGradilista = true;
            if (novaPozicija.Naziv.Contains("Gradjevinski inzenjer"))
                k.isGradjevinskiIng = true;
            if (novaPozicija.Naziv == "Arhitekta")
                k.isArhitekta = true;
            if (novaPozicija.Naziv == "Administrator")
                k.isAdmin = true;

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}