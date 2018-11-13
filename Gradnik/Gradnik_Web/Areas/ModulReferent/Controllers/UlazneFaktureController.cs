using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulReferent.Controllers
{
    [Autorizacija(KorisnikUloga.Referent)]
    public class UlazneFaktureController : Controller
    {
        MojContext ctx = new MojContext();
        public ActionResult Index()
        {
            var model = ctx.Ulaz.ToList();

            return View(model);
        }

        public ActionResult Detalji(int id)
        {
            var model = ctx.UlazStavka.Where(x => x.UlazId == id).ToList();
            return View(model);
        }
    }
}
