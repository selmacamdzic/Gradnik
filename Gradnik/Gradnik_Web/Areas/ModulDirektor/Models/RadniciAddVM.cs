using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulDirektor.Models
{
    public class RadniciAddVM
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public string ImeRoditelja { get; set; }
        [Required]
        public string JMBG { get; set; }
        public string Spol { get; set; }
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public string KontaktTelefon { get; set; }
        public string Email { get; set; }
        public string Zvanje { get; set; }
        public string Grad { get; set; }

    }
}