using System;
using System.ComponentModel.DataAnnotations;

namespace Gradnik_Data.Models
{
    public class Korisnici
    {
        public int Id { get; set; }
        public bool isActive { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        public string StrucnoZanimanje { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public KorisnikUloga KorisnikUloga { get; set; }

    }

    public enum KorisnikUloga
    {
        Admin = 1,
        Direktor,
        SefGradilista,
        Arhitekta,
        Referent,
    }
}
