using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gradnik_Data;
using System.Web.Http;

namespace Gradnik_Api.Controllers
{
    public class KorisniciController : ApiController
    {

        MojContext ctx = new MojContext();

        // GET: Korisnici
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Korisnici/Login/{username}/{password}")]
        public Korisnici Login(string username, string password)
        {

            Korisnici korisnik = ctx.Korisnici.Where(x => x.Lozinka == password && x.KorisnickoIme == username && x.isActive == true).First();


            if (korisnik != null)
            {

                return korisnik;
            }
            else
                return null;

        }

        [HttpPost]
        public IHttpActionResult Registracija(string korisnickoIme, string lozinka, string ime, string prezime, string datumRodjenja,
            string telefon, string email)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Korisnici k;

                k.KorisnickoIme = korisnickoIme;
                k.Email = email;
                k.Ime = vm.Ime;
                k.Prezime = prezime;
                k.DatumRodjenja = datumRodjenja;
                k.Lozinka = lozinka;
                k.KontaktTelefon = telefon;
                ctx.Obavijesti.Add(k);
                ctx.SaveChanges();

                return Ok();

            }

        }
    }
    }