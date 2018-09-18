using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MojContext ctx = new MojContext();
        

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password, bool? zapamti)
        {

            List<Korisnici> listaKorisnika = ctx.Korisnici.ToList();
            Korisnici k = null;
            foreach (Korisnici x in listaKorisnika)
            {
                if (x.KorisnickoIme == username && x.Lozinka == password)
                {
                    k = x;
                }
            }

            if (k == null)
            {
                ViewBag.PorukaCrvena = "Pogrešan username/password";
                return View();
            }

            Autentifikacija.PokreniNovuSesiju(k, HttpContext, false);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Logout()
        {
            Autentifikacija.PokreniNovuSesiju(null, HttpContext, true);
            return RedirectToAction("Index", "Autentifikacija");
        }
    }
}