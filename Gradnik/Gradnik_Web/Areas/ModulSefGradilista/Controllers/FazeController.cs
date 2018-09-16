using Gradnik_Data;
using Gradnik_Web.Areas.ModulSefGradilista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    public class FazeController : Controller
    {
        // GET: ModulSefGradilista/Faze

        MojContext ctx = new MojContext();
        public ActionResult Index(int id)
        {
           

            var model = new FazePrikaz2VM
            {

                listaFaza = BindFaze()

            };

            return View(model);
        }

        private List<SelectListItem> BindFaze()
        {
            //return ctx.Faze.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();
            return null;
        }
    }
}