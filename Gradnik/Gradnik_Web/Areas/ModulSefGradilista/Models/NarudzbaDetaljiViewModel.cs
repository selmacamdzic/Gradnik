using System.Collections.Generic;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class NarudzbaDetaljiViewModel
    {
        public int Id { get; set; }
        public string BrojFakture { get; set; }
        public List<SelectListItem> Dobavljaci { get; set; }
        public List<SelectListItem> Skladiste { get; set; }
        public int DobavljaciId { get; set; }
        public int SkladisteId { get; set; }
        public List<NarudzbaStavkeViewModel> Stavke { get; set; }
    }

    public class NarudzbaStavkeViewModel
    {
        public string Naziv { get; set; }
        public int MaterijalId { get; set; }
        public decimal Kolicina { get; set; }
    }
}