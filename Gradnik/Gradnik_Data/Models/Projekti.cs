using System;
using System.ComponentModel.DataAnnotations;

namespace Gradnik_Data.Models
{
    public class Projekti
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumUgovora{ get; set; }
        [DataType(DataType.Date)]
        public DateTime PocetakProjekta { get; set; }
        [DataType(DataType.Date)]
        public DateTime KrajProjekta { get; set; }
        public ProjektStatus Status { get; set; }
        public int InvestitorId { get; set; }
        public virtual Investitori Investitor { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; }
    }

    public enum ProjektStatus
    {
        Aktivan = 1,
        Realizovan,
        Zaustavljen,
    }
}
