using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class NarudzbaProcesirajViewModel
    {
        public int Id { get; set; }
        public string BrojFakture { get; set; }
        public int DobavljacId { get; set; }
        public decimal Iznos { get; set; }
        public List<NarudzbaCijenaStavkeViewModel> Stavke { get; set; }
        public int SkladisteId { get; internal set; }
    }

    public class NarudzbaCijenaStavkeViewModel
    {
        public int MaterijalId { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }
    }
}