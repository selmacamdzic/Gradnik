using Gradnik_Api.Models;
using Gradnik_Data;
using Gradnik_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Gradnik_Api.Controllers
{
    public class ProjektiController : ApiController
    {
        MojContext ctx = new MojContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var projektis = ctx.Projekti.ToList();
            return Ok(projektis);
        }

        [HttpGet]
        public IHttpActionResult GetAktivniRadnici(int tipPoslaId, int projekatId)
        {

            var radnici = ctx.RaspodjelaPosla
                    .Where(r => r.Gradiliste.ProjektiId == projekatId && r.TipPoslaId == tipPoslaId)
                    .Select(x => new
                    {
                        Id = x.Radnik.Id,
                        Ime = x.Radnik.Ime,
                        Prezime = x.Radnik.Prezime,
                        Zvanje = x.Radnik.Zvanje,
                        JMBG = x.Radnik.JMBG,
                        DatumRodjenja = x.Radnik.DatumRodjenja,
                        Email = x.Radnik.Email,
                        KontaktTelefon = x.Radnik.KontaktTelefon
                    }).ToList();

            return Ok(radnici);
        }

        [HttpGet]
        public IHttpActionResult GetTipPoslaByProjekatId(int projekatId)
        {

            var tipposla = ctx.RaspodjelaPosla
                    .Where(r => r.Gradiliste.ProjektiId == projekatId )
                    .Select(x => new
                    {
                        TipPostId = x.TipPosla.Id,
                        TipPoslaNaziv = x.TipPosla.Naziv,
                        count = ctx.RaspodjelaPosla.Where(d => d.Gradiliste.ProjektiId == projekatId).Count()
                    }).ToList();

            return Ok(tipposla);
        }

        [HttpPost]
        public IHttpActionResult AddRadnik(AddRadnikVM obj)
        {
            List<Radnici> radnici = new List<Radnici>();

            var raspodjelaPosla = ctx.RaspodjelaPosla.FirstOrDefault(d => d.TipPoslaId == obj.JobTypeId);

            foreach (var item in obj.SelectedEmployees)
            {
                ctx.RaspodjelaPosla.Add(
                    new RaspodjelaPosla
                    {
                        RadnikId = item,
                        GradilisteId = raspodjelaPosla.GradilisteId,
                        PocetakRada = DateTime.UtcNow,
                        KrajRada = DateTime.UtcNow.AddMonths(1),
                        TipPoslaId = obj.JobTypeId,
                        KorisnikId = 1
                    });
            }

            ctx.SaveChanges();

            return Ok();
        }

    }
}
