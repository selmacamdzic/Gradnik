using Gradnik_Api.Models;
using Gradnik_Data;
using Gradnik_Data.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Gradnik_Api.Controllers
{
    public class RadniciController : ApiController
    {
        MojContext ctx = new MojContext();

        public IHttpActionResult GetRadnici()
        {
            var radnici = ctx.Radnici.ToList();

            return Ok(radnici);
        }

        public IHttpActionResult GetSlobodniRadnici()
        {
            var radnici = ctx.Radnici.Where(x=>x.isZaduzen == false).ToList();

            return Ok(radnici);
        }

        [HttpGet]
        public IHttpActionResult Login(string username, string password)
        {
            var korisnik = ctx.Korisnici.FirstOrDefault(r => r.KorisnickoIme == username && r.Lozinka == password);

            if (korisnik == null)
            {
                return NotFound();
            }
            return Ok(korisnik);
        }

        [HttpPost]
        public IHttpActionResult Evidencija(EvidencijaVM obj)
        {
            var raspodjela = ctx.RaspodjelaPosla.FirstOrDefault(x=> x.RadnikId == obj.employeeId && x.KrajRada == null);
            var sati = new Sati
            {
                Datum = DateTime.UtcNow,
                OdradjeniSati = obj.radniSati,
                RaspodjelaPoslaId = raspodjela.Id
            };
            ctx.Sati.Add(sati);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
