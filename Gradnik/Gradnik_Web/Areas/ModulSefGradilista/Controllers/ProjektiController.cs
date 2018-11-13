using Gradnik_Data;
using System.Linq;
using System.Web.Mvc;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using Gradnik_Web.Areas.ModulSefGradilista.Models;
using System;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    [Autorizacija(KorisnikUloga.SefGradilista)]
    public class ProjektiController : Controller
    {
        // GET: ModulSefGradilista/Projekti

        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            //uzeti trenutno logiranog korisnika i staviti u uslov da ispise samo njegove projekte
            var model = ctx.Projekti.Where(x => x.Status == ProjektStatus.Aktivan).ToList();

            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = ctx.Projekti.Where(x => x.Status == ProjektStatus.Aktivan).ToList();

            return View(model);
        }

        public ActionResult Pregled(int id)
        {
            var model = ctx.Projekti.Find(id);

            return View(model);
        }
        public ActionResult Realizovani()
        {
            var model = ctx.Projekti.Where(x => x.Status == ProjektStatus.Aktivan).ToList();

            return View(model);
        }

        public ActionResult PregledRadnika(int id)
        {
            var raspodjela = ctx.RaspodjelaPosla
                            .Where(x => x.Gradiliste.Id == id && x.KrajRada == null);

            var radnici = raspodjela.Select(x => new RapsodjelaRadnikaPrikazVM
            {
                RadnikId = x.RadnikId,
                Opis = x.Opis,
                PocetakRada = x.PocetakRada,
                TipPosla = x.TipPosla.Naziv,
                RaspodjelaId = x.Id,
                Gradiliste = x.Gradiliste.Adresa
            }).ToList();

            ViewBag.GradilisteId = id;
            return View(radnici);
        }

        public ActionResult UkloniRadnika(int radnikId, int raspodjelaId)
        {
            var raspodjela = ctx.RaspodjelaPosla.FirstOrDefault(r=> r.Id == raspodjelaId && r.RadnikId == radnikId);
            raspodjela.KrajRada = DateTime.UtcNow;
            var radnik = ctx.Radnici.FirstOrDefault(r => r.Id == radnikId);
            radnik.isZaduzen = false;
            ctx.SaveChanges();

            return RedirectToAction("PregledRadnika", new { id = raspodjela.Gradiliste.ProjektiId });
        }
    }
}