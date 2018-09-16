using System.Collections.Generic;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class NarudzbaDetaljiViewModel
    {
        public int Id { get; set; }
        public List<SelectListItem> Dobavljaci { get; set; }
        public int DobavljaciId { get; set; }
        public List<NarudzbaStavkeViewModel> Stavke { get; set; }
    }

    public class NarudzbaStavkeViewModel
    {
        public string Naziv { get; set; }
        public decimal Kolicina { get; set; }
    }
}