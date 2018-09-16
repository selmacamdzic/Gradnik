using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulAdmin.Models;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulAdmin.Controllers
{
    public class MaterijaliController : Controller
    {
        MojContext ctx = new MojContext();
        // GET: ModulAdmin/Materijali
        public ActionResult Index()
        {
            var model = ctx.Materijali.ToList();
            return View(model);
        }


        public ActionResult Delete(int id)
        {
            Materijal m = ctx.Materijali.Find(id);
            ctx.Materijali.Remove(m);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Uredi(int id)
        {
            Materijal m = ctx.Materijali.Find(id);
            var model = new MaterijaliDodajVM
            {
                Id = m.Id,
                Naziv = m.Naziv,
                Opis = m.Opis
            };
            return View(model);
        }

        public ActionResult Dodaj()
        {
            var model = new MaterijaliDodajVM();
            return View(model);
        }

        public ActionResult Spremi(MaterijaliDodajVM vm)
        {
            //TODO provjeriti sta sa validacijom kada je poziv iz uredi
            if (!ModelState.IsValid)
            {
                return View("Dodaj", vm);
            }

            Materijal m;
            if (vm.Id == 0)
            {
                m = new Materijal();
                ctx.Materijali.Add(m);
            }
            else
            {
                m = ctx.Materijali.Find(vm.Id);
            }

            m.Naziv = vm.Naziv;
            m.Opis = vm.Opis;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}