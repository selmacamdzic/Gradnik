using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using Gradnik_Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    [Autorizacija(KorisnikUloga.SefGradilista)]
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