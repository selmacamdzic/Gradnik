using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DateTime DatumRodjenja { get; set; }
        public string StrucnoZanimanje { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }


        public bool isDirektor { get; set; }
        public bool isSefGradilista { get; set; }
        public bool isGradjevinskiIng{ get; set; }
        public bool isArhitekta { get; set; }
        public bool isReferent { get; set; }
        public bool isAdmin { get; set; }



        public int KorisnikPozicijaId { get; set; }
        public virtual KorisnikPozicija KorisnikPozicija { get; set; }
    }
}
