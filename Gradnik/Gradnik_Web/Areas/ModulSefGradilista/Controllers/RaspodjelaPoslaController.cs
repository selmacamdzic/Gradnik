using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulSefGradilista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    public class RaspodjelaPoslaController : Controller
    {
        // GET: ModulSefGradilista/RaspodjelaPosla

        MojContext ctx = new MojContext();
        public ActionResult Dodaj(int gradilisteId)
        {
            var model = new RaspodjelaPoslaDodajVM
            {
                listaRadnik = BindRadnici(),
                GradilisteId = gradilisteId,
                TipPosla = ctx.TipPosla
                            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList()
            };

            return View(model);
        }

        private List<SelectListItem> BindRadnici()
        {
            return ctx.Radnici
                .Where(x => x.isZaduzen == false)
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Ime + " " + x.Prezime }).ToList();
        }

        public ActionResult Spremi(RaspodjelaPoslaDodajVM vm)
        {
            RaspodjelaPosla raspodjelaPosla = new RaspodjelaPosla
            {
                GradilisteId = vm.GradilisteId,
                PocetakRada = vm.PocetakRada,
                KrajRada = vm.PocetakRada,
                TipPoslaId = vm.TipPoslaId,
                Opis = vm.Opis,
                RadnikId = vm.RadnikId,
                //setati logiranog korisnika
                KorisnikId = 3,
            };
            
            ctx.RaspodjelaPosla.Add(raspodjelaPosla);
            ctx.SaveChanges();

            return RedirectToAction("TipPoslaByGradiliste", "TipPosla", new
            {
                gradilisteId = vm.GradilisteId
            });
        }


        //public ActionResult PrikazRadnika(int gradilisteId, int tipPoslaId)
        //{

        //    List<PrikazRadnikaRow> listRadnik = new List<PrikazRadnikaRow>();

        //    List<RaspodjelaPosla> raspodjela = ctx.RaspodjelaPosla.Where(x => x.GradilisteId == gradilisteId && x.TipPoslaId == tipPoslaId).ToList();
        //    foreach (RaspodjelaPosla item in raspodjela)
        //    {
        //        PrikazRadnikaRow row = new PrikazRadnikaRow();
        //        row.gradilisteId = item.Gradiliste.Id;
        //        row.radnikId = item.Radnik.Id;
        //        row.tipPoslaId = item.TipPosla.Id;
        //        row.imePrezime = item.Radnik.Ime + " " + item.Radnik.Prezime;
        //        row.Grad = item.Radnik.Grad;
        //        row.JMBG = item.Radnik.JMBG;
        //        row.KontaktTelefon = item.Radnik.KontaktTelefon;
        //        row.tipPosla = item.TipPosla.Naziv;
        //        row.isZaduzen = item.KrajRada == null ? true : false;

        //        listRadnik.Add(row);
        //    }
        //    var model = new PrikazRadnikaVM
        //    {
        //        listaRadnika = listRadnik,
        //        tiposlaId = tipPoslaId,
        //        gradilisteId = gradilisteId
        //    };



        //    return View(model);
        //}

        public ActionResult Evidentiraj(int gradilisteId)
        {
            List<PrikazRadnikaRow> listRadnik = new List<PrikazRadnikaRow>();

            List<RaspodjelaPosla> raspodjela = ctx.RaspodjelaPosla.Where(x => x.GradilisteId == gradilisteId).ToList();
            foreach (RaspodjelaPosla item in raspodjela)
            {
                PrikazRadnikaRow row = new PrikazRadnikaRow();
                row.gradilisteId = item.Gradiliste.Id;
                row.radnikId = item.Radnik.Id;
                row.tipPoslaId = item.TipPosla.Id;
                row.imePrezime = item.Radnik.Ime + " " + item.Radnik.Prezime;
                row.Grad = item.Radnik.Grad;
                row.JMBG = item.Radnik.JMBG;
                row.KontaktTelefon = item.Radnik.KontaktTelefon;
                row.tipPosla = item.TipPosla.Naziv;
                row.isZaduzen = item.KrajRada == null ? true : false;

                listRadnik.Add(row);
            }
            var model = new PrikazRadnikaVM
            {
                listaRadnika = listRadnik,
                gradilisteId = gradilisteId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Evidentiraj(EvidencijaVM obj)
        {
            foreach (RadnikRadniSatiVM x in obj.Radnici)
            {
                Sati item = new Sati();
                item.Datum = obj.DatumRada;
                item.isPlaceno = false;
                item.OdradjeniSati = x.RadniSati;

                RaspodjelaPosla raspodjelaPosla = ctx.RaspodjelaPosla
                                                        .Where(y => y.RadnikId == x.RadnikId && y.GradilisteId == obj.GradilisteId)
                                                        .FirstOrDefault();

                if (raspodjelaPosla != null)
                {
                    item.RaspodjelaPoslaId = raspodjelaPosla.Id;
                    ctx.Sati.Add(item);
                    ctx.SaveChanges();
                }
            }

            return Json(JsonRequestBehavior.AllowGet);
        }
    };

}