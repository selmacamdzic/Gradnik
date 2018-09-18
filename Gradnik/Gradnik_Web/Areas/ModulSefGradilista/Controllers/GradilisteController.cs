using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulSefGradilista.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    public class GradilisteController : Controller
    {
        // GET: ModulSefGradilista/Gradiliste

        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            var model = ctx.Gradiliste.ToList();
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
    }
}