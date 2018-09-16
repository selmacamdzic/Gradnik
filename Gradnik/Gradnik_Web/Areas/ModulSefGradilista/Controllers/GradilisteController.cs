using Gradnik_Data;
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
    }
}