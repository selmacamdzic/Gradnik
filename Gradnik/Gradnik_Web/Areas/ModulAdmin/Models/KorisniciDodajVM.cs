using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulAdmin.Models
{
    public class KorisniciDodajVM
    {
        public int KorisnikId { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }   
        public string Lozinka { get; set; }

        public string Email { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }
        public string StrucnoZanimanje { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Required]
        public string KontaktTelefon { get; set; }

        [Required]
        public int KorisnikPozicijaId { get; set; }
        public List<SelectListItem> listaPozicija;
    }
}