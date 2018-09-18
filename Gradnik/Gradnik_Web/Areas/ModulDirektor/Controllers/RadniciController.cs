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
    public class RadniciController : Controller
    {
        // GET: ModulDirektor/Radnici
        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            var model = ctx.Radnici.ToList();
            return View(model);
        }


        public ActionResult Profile(int id)
        {
            var model = ctx.Radnici.Find(id);

            return View(model);

        }

        public ActionResult Add()
        {
         var model = new RadniciAddVM();
            return View(model);
        }

        public ActionResult Save(RadniciAddVM vm)
        {

            if (!ModelState.IsValid)
            {
                return View("Add", vm);
            }


            Radnici r = new Radnici();
            
            r.Ime = vm.Ime;
            r.Prezime = vm.Prezime;
            r.ImeRoditelja = vm.ImeRoditelja;
            r.JMBG = vm.JMBG;
            r.DatumRodjenja = vm.DatumRodjenja;
            r.Spol = vm.Spol;
            r.KontaktTelefon = vm.KontaktTelefon;
            r.Email = vm.Email;

            ctx.Radnici.Add(r);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = ctx.Radnici.Find(id);

            return View(model);
        }

        public ActionResult SaveEdit(Radnici vm)
        {
            Radnici r = ctx.Radnici.Find(vm.Id);

            r.Ime = vm.Ime;
            r.Prezime = vm.Prezime;
            r.ImeRoditelja = vm.ImeRoditelja;
            r.JMBG = vm.JMBG;
            r.DatumRodjenja = vm.DatumRodjenja;
            r.Spol = vm.Spol;
            r.KontaktTelefon = vm.KontaktTelefon;
            r.Email = vm.Email;
            
            ctx.SaveChanges();

            return RedirectToAction("Edit");
        }

        public ActionResult ActiveWorkInfo(int id)
        {
            var model = new WorkInfoVM {

                //dodati uslov u raspodjeli posla da je kraj null

                workInfo = ctx.RaspodjelaPosla.Where(x=>x.RadnikId==id && x.KorisnikId==1014).Select(x => new WorkInfoRow
                {
                    RaspodjelaPoslaId = x.Id,
                    workareaName = x.Opis,
                    jobtitle = x.TipPosla.Naziv,
                    startDate = x.PocetakRada,
                    hours = ctx.Sati.Where(y => y.RaspodjelaPoslaId == x.Id && y.isPlaceno == true).Sum(y => y.OdradjeniSati)

                }).FirstOrDefault()
            };

            return View(model);
        }

        public ActionResult InactiveWorkInfo(int id)
        {
            var model = new InActiveWorkInfo
            {

                //dodati uslov u raspodjeli posla da je kraj unesen

                inactiveWorkInfos = ctx.RaspodjelaPosla.Where(x => x.RadnikId==id).Select(x => new WorkInfoRow
                {
                    RaspodjelaPoslaId = x.Id,
                    workareaName = x.Gradiliste.Adresa,
                    jobtitle = x.TipPosla.Naziv,
                    startDate = x.PocetakRada,
                    hours = ctx.Sati.Where(y => y.RaspodjelaPoslaId == x.Id).Sum(y => y.OdradjeniSati)

                }).ToList()
            };

            return View(model);
        }
    }
}