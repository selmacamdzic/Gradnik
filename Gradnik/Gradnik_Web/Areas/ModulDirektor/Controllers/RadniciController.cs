using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Areas.ModulDirektor.Models;
using Gradnik_Web.Helper;
using System.Linq;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulDirektor.Controllers
{
    [Autorizacija(KorisnikUloga.Direktor)]
    public class RadniciController : Controller
    {
        // GET: ModulDirektor/Radnici
        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            var model = ctx.Radnici.ToList();
            return View(model);
        }


        public ActionResult Profile(int id)
        {
            var model = ctx.Radnici.Find(id);

            return View(model);

        }

        public ActionResult Add()
        {
         var model = new RadniciAddVM();
            return View(model);
        }

        public ActionResult Spremi(RadniciAddVM vm)
        {
            //TODO provjeriti sta sa validacijom kada je poziv iz uredi
            if (!ModelState.IsValid)
            {
                return View("Dodaj", vm);
            }

            Radnici i;
            if (vm.Id == 0)
            {
                i = new Radnici();
                ctx.Radnici.Add(i);
            }
            else
            {
                i = ctx.Radnici.Find(vm.Id);
            }

            i.DatumRodjenja = vm.DatumRodjenja;
            i.Email = vm.Email;
            i.KontaktTelefon = vm.KontaktTelefon;
            i.Grad = vm.Grad;
            i.Ime = vm.Ime;
            i.Prezime = vm.Prezime;
            i.Spol = vm.Spol;
            i.Zvanje = vm.Zvanje;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Save(RadniciAddVM vm)
        {

            if (!ModelState.IsValid)
            {
                return View("Add", vm);
            }


            Radnici r = new Radnici();
            
            r.Ime = vm.Ime;
            r.Prezime = vm.Prezime;
            r.ImeRoditelja = vm.ImeRoditelja;
            r.JMBG = vm.JMBG;
            r.DatumRodjenja = vm.DatumRodjenja;
            r.Spol = vm.Spol;
            r.KontaktTelefon = vm.KontaktTelefon;
            r.Email = vm.Email;

            ctx.Radnici.Add(r);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = ctx.Radnici.Find(id);

            return View(model);
        }

        public ActionResult SaveEdit(Radnici vm)
        {
            Radnici r = ctx.Radnici.Find(vm.Id);

            r.Ime = vm.Ime;
            r.Prezime = vm.Prezime;
            r.ImeRoditelja = vm.ImeRoditelja;
            r.JMBG = vm.JMBG;
            r.DatumRodjenja = vm.DatumRodjenja;
            r.Spol = vm.Spol;
            r.KontaktTelefon = vm.KontaktTelefon;
            r.Email = vm.Email;
            
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detalji(int id)
        {
            var detaljiVM = new RadniciDetaljiVM
            {
                Radnik = ctx.Radnici.FirstOrDefault(k => k.Id == id),
                ZavrseniProjekti = ctx.RaspodjelaPosla.Where(r => r.RadnikId == id).Select(x => new RadniciProjektiVM
                {
                    Datum = x.Gradiliste.Projekti.DatumUgovora,
                    Naziv = x.Gradiliste.Projekti.Naziv,
                    ProjektId = x.Gradiliste.ProjektiId
                }).ToList(),
                TrenutniProjekat = ctx.RaspodjelaPosla
                    .Where(r => r.KrajRada == null && r.Id == id)
                    .Select(x => new RadniciProjektiVM
                    {
                        Datum = x.Gradiliste.Projekti.DatumUgovora,
                        Naziv = x.Gradiliste.Projekti.Naziv,
                        ProjektId = x.Gradiliste.ProjektiId
                    }).FirstOrDefault()
            };

            return View(detaljiVM);
        }
    }
}