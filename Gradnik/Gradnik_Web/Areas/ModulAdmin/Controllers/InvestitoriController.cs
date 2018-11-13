using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulAdmin.Controllers
{
    [Autorizacija(KorisnikUloga.Admin)]
    public class InvestitoriController : Controller
    {
        // GET: ModulAdmin/Investitori
        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            var model = ctx.Investitori.ToList();
            return View(model);
        }

        public ActionResult Uredi(int id)
        {
            Investitori model = ctx.Investitori.Find(id);
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new Investitori();
            return View(model);
        }

        public ActionResult Spremi(Investitori vm)
        {
            //TODO provjeriti sta sa validacijom kada je poziv iz uredi
            if (!ModelState.IsValid)
            {
                return View("Dodaj", vm);
            }

            Investitori i;
            if (vm.Id == 0)
            {
                i = new Investitori();
                ctx.Investitori.Add(i);
            }
            else
            {
                i = ctx.Investitori.Find(vm.Id);
            }

            i.Naziv = vm.Naziv;
            i.ImeOdgovorneOsobe = vm.ImeOdgovorneOsobe;
            i.KontaktTelefon = vm.KontaktTelefon;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}