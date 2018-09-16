using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulAdmin.Models
{
    public class DobavljaciDodajVM
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adresa { get; set; }
        public string Email { get; set; }
        [Required]
        public string KontaktTelefon { get; set; }
    }
}