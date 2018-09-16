using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulEngineering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gradnik_Web.Areas.ModulEngineering.Controllers
{
    public class TehnickiOpisController : Controller
    {
        // GET: ModulEngineering/TehnickiOpis
        MojContext ctx = new MojContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var model = new TehnickiOpisAddVM {

                listaFaza = BindFaze()
            };
            return View(model);
        }

        private List<SelectListItem> BindFaze()
        {
            //return ctx.Faze.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();
            return null;
        }

        public ActionResult Save(TehnickiOpisAddVM vm)
        {
            //TehnickiOpisi tehnickiOpis = new TehnickiOpisi();
            //tehnickiOpis.Izvjestaj = vm.Izvjestaj;
            //tehnickiOpis.NamjenaObjekta = vm.NamjenaObjekta;
            //tehnickiOpis.Odrzavanje = vm.Odrzavanje;
            //tehnickiOpis.Opis = vm.Opis;
            //tehnickiOpis.OstaliRadovi = vm.OstaliRadovi;
            //tehnickiOpis.VijekTrajanja = vm.VijekTrajanja;

            //ctx.TehnickiOpisi.Add(tehnickiOpis);

            //Projekti project = ctx.Projekti.Find(vm.ProjektId);
            //project.TehnickiOpis = tehnickiOpis;

            //ctx.SaveChanges();


            //StatickiProracunAddVM model = new StatickiProracunAddVM { FazeId=vm.FazeId,TehnickiOpisId=tehnickiOpis.Id };
            //TempData["myObject"] = model;

            return RedirectToAction("Add", "StatickiProracun");
        }
    }
}