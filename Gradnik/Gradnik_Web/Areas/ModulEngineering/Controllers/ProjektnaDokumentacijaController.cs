using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulEngineering.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulEngineering.Controllers
{
    public class ProjektnaDokumentacijaController : Controller
    {
        // GET: ModulEngineering/ProjektnaDokumentacija
        MojContext ctx = new MojContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int id)
        {
            var model = new ProjektnaDokumentacijaAddVM();
            model.projekatId = id;

            return View(model);
        }
        [HttpPost]
        public ActionResult Save(ProjektnaDokumentacijaAddVM vm)
        {

            //ProjektnaDokumentacija projectDocument = new ProjektnaDokumentacija();
            //if (vm.CrtezPresjek!=null)
            //{
            //    BinaryReader rdr = new BinaryReader(vm.CrtezPresjek.InputStream);
            //    projectDocument.CrtezPresjek = rdr.ReadBytes((int)vm.CrtezPresjek.ContentLength);
               

            //}

            //if (vm.CrtezOsnova!=null)
            //{
            //    BinaryReader rdr = new BinaryReader(vm.CrtezOsnova.InputStream);
            //    projectDocument.CrtezOsnova = rdr.ReadBytes((int)vm.CrtezOsnova.ContentLength);

            //}

            //if (vm.CrtezKrov != null)
            //{
            //    BinaryReader rdr = new BinaryReader(vm.CrtezKrov.InputStream);
            //    projectDocument.CrtezKrov = rdr.ReadBytes((int)vm.CrtezKrov.ContentLength);

            //}
            //if (vm.CrtezFasada != null)
            //{
            //    BinaryReader rdr = new BinaryReader(vm.CrtezFasada.InputStream);
            //    projectDocument.CrtezFasada = rdr.ReadBytes((int)vm.CrtezFasada.ContentLength);

            //}

            //projectDocument.Opis = vm.Opis;
         
            //ctx.ProjektnaDokumentacija.Add(projectDocument);
            

            //Projekti project = ctx.Projekti.Find(vm.projekatId);
            //project.ProjektnaDokumentacija=projectDocument;

            //ctx.SaveChanges();

            return RedirectToAction("Index","Projekti");
        }
    }
}