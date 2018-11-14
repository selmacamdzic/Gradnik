using Gradnik_Data;
using Gradnik_Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulEngineering.Controllers
{
    public class SkladisteController : Controller
    {
        MojContext ctx = new MojContext();
        public ActionResult Index()
        {

            var model = ctx.Database.SqlQuery<StanjeSkladistaDto>("SELECT * FROM StanjeSkladista").ToList();
            return View(model);
        }
    }
}