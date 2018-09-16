using System;
using System.Collections.Generic;

namespace Gradnik_Data.Models
{
    public enum NarudzbaStatus
    {
        Aktivna = 1,
        Procesirana,
        Odbijena
    }
    public class Narudzba
    {
        public int Id { get; set; }
        public Korisnici Korisnik { get; set; }
        public int KorisnikId { get; set; }
        public NarudzbaStatus NarudzbaStatus { get; set; }
        public DateTime Datum { get; set; }

        public List<Ulaz> Ulazi { get; set; }
        public List<NarudbzbaStavka> NarudbzbaStavka { get; set; }

    }
}