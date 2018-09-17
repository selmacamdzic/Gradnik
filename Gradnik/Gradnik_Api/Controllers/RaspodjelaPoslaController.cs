using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gradnik_Api.Controllers
{
    public class RaspodjelaPoslaController : ApiController
    {
        MojContext ctx = new MojContext();

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult Spremi(RaspodjelaPoslaDodajVM vm)
        {
            foreach (int radnikId in vm.radniciId)
            {
                RaspodjelaPosla raspodjelaPosla = new RaspodjelaPosla
                {
                    GradilisteId = vm.GradilisteId,
                    PocetakRada = vm.PocetakRada,
                    KrajRada = vm.PocetakRada,
                    TipPoslaId = vm.TipPoslaId,
                    Opis = vm.Opis,
                    RadnikId =radnikId,
                    //setati logiranog korisnika
                    KorisnikId = 3,
                };

                ctx.RaspodjelaPosla.Add(raspodjelaPosla);
                ctx.SaveChanges();
            }

            return StatusCode(HttpStatusCode.OK);
        }

        [HttpGet]
        [ResponseType(typeof(RaspodjelaPoslaDodajVM))]
        public RaspodjelaPoslaDodajVM Dodaj(int gradilišteId,int tipPoslaId)
        {
            List<PrikazRadnikaRow> listRadnik = new List<PrikazRadnikaRow>();

            List<RaspodjelaPosla> raspodjela = ctx.RaspodjelaPosla.Where(x => x.GradilisteId == gradilisteId && x.TipPoslaId == tipPoslaId).ToList();
            foreach (RaspodjelaPosla item in raspodjela)
            {
                PrikazRadnikaRow row = new PrikazRadnikaRow();
                row.gradilisteId = item.Gradiliste.Id;
                row.radnikId = item.Radnik.Id;
                row.tipPoslaId = item.TipPosla.Id;
                row.imePrezime = item.Radnik.Ime + " " + item.Radnik.Prezime;
                row.Grad = item.Radnik.Grad;
                row.JMBG = item.Radnik.JMBG;
                row.KontaktTelefon = item.Radnik.KontaktTelefon;
                row.tipPosla = item.TipPosla.Naziv;
                row.isZaduzen = item.KrajRada == null ? true : false;

                listRadnik.Add(row);
            }
            var model = new PrikazRadnikaVM
            {
                listaRadnika = listRadnik,
                tiposlaId = tipPoslaId,
                gradilisteId = gradilisteId
            };

            return Ok(model);
        }

        private List<RadnikVM> BindRadnici()
        {
            return ctx.Radnici
                .Where(x => x.isZaduzen == false)
                .Select(x => new RadnikVM { Id = x.Id.ToString(), Naziv = x.Ime + " " + x.Prezime }).ToList();

            
        }
    }
}
