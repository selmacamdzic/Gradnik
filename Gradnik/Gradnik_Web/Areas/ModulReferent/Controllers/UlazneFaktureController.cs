using Gradnik_Data;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulReferent.Controllers
{
    public class UlazneFaktureController : Controller
    {

        MojContext ctx = new MojContext();
        public ActionResult Detalji()
        {
            var model = ctx.Ulaz.ToList();

            return View(model);
        }
    }
}
