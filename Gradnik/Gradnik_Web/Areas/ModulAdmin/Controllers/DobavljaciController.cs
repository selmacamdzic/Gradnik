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
    public class DobavljaciController : Controller
    {
        MojContext ctx = new MojContext();
        // GET: ModulAdmin/Dobavljaci
        public ActionResult Index()
        {
            var model = ctx.Dobavljaci.ToList().OrderBy(x=>x.Id);
            return View(model);
        }


        public ActionResult Delete(int id)
        {
            Dobavljaci d = ctx.Dobavljaci.Find(id);
            ctx.Dobavljaci.Remove(d);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Uredi(int id)
        {
            Dobavljaci d = ctx.Dobavljaci.Find(id);
            var model = new DobavljaciDodajVM
            {
                Id = d.Id,
                Naziv=d.Naziv,
                Adresa=d.Adresa,
                KontaktTelefon=d.KontaktTelefon,
                Email=d.Email
            };
            
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new DobavljaciDodajVM();          
            return View(model);
        }

        //TODO provjeriti sta sa validacijom kada je poziv iz uredi
        public ActionResult Spremi(DobavljaciDodajVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Dodaj", vm);
            }

            Dobavljaci dobavljac;
            if (vm.Id==0)
            {
                dobavljac = new Dobavljaci();
                ctx.Dobavljaci.Add(dobavljac);

            }

            else
            {
                dobavljac = ctx.Dobavljaci.Find(vm.Id);
            }

            dobavljac.Adresa = vm.Adresa;
            dobavljac.Email = vm.Email;
            dobavljac.KontaktTelefon = vm.KontaktTelefon;
            dobavljac.Naziv = vm.Naziv;

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}