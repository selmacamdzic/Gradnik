using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulEngineering.Controllers
{
    [Autorizacija(KorisnikUloga.Arhitekta)]
    public class HomeController : Controller
    {
        // GET: ModulEngineering/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}