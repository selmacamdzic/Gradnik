using System;
using System.Collections.Generic;

namespace Gradnik_Data.Models
{
    public class Ulaz
    {
        public int Id { get; set; }
        public string BrojFakture { get; set; }
        public decimal Iznos { get; set; }
        public string Valuta { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int? DobavljacId { get; set; }
        public virtual Dobavljaci Dobavljac { get; set; }
        public List<UlazStavka> UlazStavke { get; set; }
        public virtual Narudzba Narudzba { get; set; }
        public int NarudzbaId { get; set; }
        public virtual Skladiste Skladiste { get; set; }
        public int SkladisteId { get; set; }
    }
}