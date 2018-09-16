using Gradnik_Data;
using System.Linq;
using System.Web.Mvc;
using Gradnik_Data.Models;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
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
    }
}