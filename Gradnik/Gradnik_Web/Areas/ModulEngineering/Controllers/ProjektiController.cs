using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulEngineering.Models;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulEngineering.Controllers
{
    [Autorizacija(KorisnikUloga.Arhitekta)]
    public class ProjektiController : Controller
    {
        // GET: ModulEngineering/Projekti
        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            var model = ctx.Projekti.Where(x => x.Status == ProjektStatus.Aktivan).ToList();

            return View(model);
        }

        public ActionResult Dokumentacija(int Id)
        {
            var model = new ProjektnaDokumentacijaAddVM
            {
                ProjekatId = Id
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult DodajDokumentaciju(ProjektnaDokumentacijaAddVM obj)
        {
            byte[] uploadedFile = new byte[obj.File.InputStream.Length];
            obj.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            var dokument = new Dokumentacija
            {
                File = uploadedFile,
                ProjekatId = obj.ProjekatId,
                Naziv = obj.File.FileName,
                Opis = obj.Opis,
                Datum = DateTime.UtcNow
            };

            ctx.Dokumentacija.Add(dokument);
            ctx.SaveChanges();

            return RedirectToAction("Dokumentacija", new { id = obj.ProjekatId});
        }

        
        public ActionResult _ListaDokumenata(int id)
        {
            var lista = ctx.Dokumentacija.Where(x => x.ProjekatId == id).ToList();

            return View(lista);
        }

        [HttpGet]
        public FileResult DownLoadFile(int id)
        {
            var file = ctx.Dokumentacija.FirstOrDefault(x => x.Id == id);
            var mimeType = MimeMapping.GetMimeMapping(file.Naziv);
            return File(file.File, mimeType, file.Naziv);

        }

        [HttpGet]
        public ActionResult ObrisiDokument(int id)
        {
            var file = ctx.Dokumentacija.FirstOrDefault(x => x.Id == id);
            ctx.Dokumentacija.Remove(file);
            ctx.SaveChanges();

            return RedirectToAction("Dokumentacija", new { id = file.ProjekatId });
        }
    }
}