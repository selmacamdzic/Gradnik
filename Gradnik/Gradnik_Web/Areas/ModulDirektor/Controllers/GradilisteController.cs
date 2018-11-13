using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulDirektor.Controllers
{
    [Autorizacija(KorisnikUloga.Direktor)]
    public class GradilisteController : Controller
    {
        // GET: ModulDirektor/Gradiliste

        MojContext ctx = new MojContext();

        public ActionResult Index(int id)
        {
            var gradiliste = ctx.Gradiliste
                .Where(x => x.ProjektiId == id)
                .ToList();

            return View(gradiliste);
        }
    }
}