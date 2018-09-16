using Gradnik_Data.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulDirektor.Models
{
    public class ProjektiAddVM
    {
        public List<SelectListItem> Korisnik { get; set; }
        public List<SelectListItem> Investitor { get; set; }
        public int InvestitorId { get; set; }
        public int KorisnikId { get; set; }
        public Projekti Projekat { get; set; }
        public Gradiliste Gradiliste { get; set; }
    }
}