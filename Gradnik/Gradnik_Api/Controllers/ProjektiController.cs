﻿using Gradnik_Api.Models;
using Gradnik_Data;
using Gradnik_Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            var projektis = ctx.Projekti
                .Select(x => new ProjektiPrikazVM
                {
                    DatumUgovora = x.DatumUgovora.ToString(),
                    Id = x.Id,
                    KorisnikId = x.KorisnikId,
                    KrajProjekta = x.KrajProjekta.ToString(),
                    Lokacija = x.Lokacija,
                    Naziv = x.Naziv,
                    PocetakProjekta = x.PocetakProjekta.ToString(),
                    Status = x.Status == ProjektStatus.Aktivan ? true : false,
                    Opis = x.Investitor.Naziv + "-" + x.Lokacija
                })
                .ToList();
            return Ok(projektis);
        }

        [HttpGet]
        public IHttpActionResult GetAktivniRadnici(int tipPoslaId, int projekatId)
        {

            var radnici = ctx.RaspodjelaPosla
                    .Where(r => r.Gradiliste.ProjektiId == projekatId && r.TipPoslaId == tipPoslaId && r.KrajRada == null)
                    .Select(x => new
                    {
                        Id = x.Radnik.Id,
                        Ime = x.Radnik.Ime,
                        Prezime = x.Radnik.Prezime,
                        Zvanje = x.Radnik.Zvanje ?? "Zvanje",
                        JMBG = x.Radnik.JMBG,
                        DatumRodjenja = x.Radnik.DatumRodjenja,
                        Email = x.Radnik.Email,
                        KontaktTelefon = x.Radnik.KontaktTelefon,
                        Adresa = x.Radnik.Grad,
                        RadniSati = (int?)ctx.Sati.Where(s => s.RaspodjelaPoslaId == x.Id).Sum(o => o.OdradjeniSati) ?? 0
                    }).ToList();

            return Ok(radnici);
        }

        [HttpGet]
        public IHttpActionResult GetTipPoslaByProjekatId(int id)
        {
            var gradiliste = ctx.Gradiliste.FirstOrDefault(x => x.ProjektiId == id);

            var SqlParameters = new[]
           {
               new SqlParameter("Id", SqlDbType.Int) { Value = gradiliste.Id }
            };

            var query = ctx.Database.SqlQuery<TipPoslovaPoGradilistuVM>("SELECT * FROM TipPoslovaPoGradilistu WHERE GradilisteId = @Id", SqlParameters)
                                        .ToList();


            return Ok(query);
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
                        KorisnikId = 3
                    });
            }

            ctx.SaveChanges();

            return Ok();
        }

        public IHttpActionResult DodajRadnika(DodajRadnikaVM obj)
        {
            var gradiliste = ctx.Gradiliste.FirstOrDefault(x => x.ProjektiId == obj.projektId);

            foreach (var item in obj.selectedEmployees)
            {
                ctx.RaspodjelaPosla.Add(new RaspodjelaPosla
                {
                    GradilisteId = gradiliste.Id,
                    PocetakRada = DateTime.UtcNow,
                    TipPoslaId = obj.jobTypeId,
                    RadnikId = item,
                    KorisnikId = 3
                });
            }
            ctx.SaveChanges();
            return Ok();
        }

    }
}
