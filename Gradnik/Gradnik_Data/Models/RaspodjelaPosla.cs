using System;

namespace Gradnik_Data.Models
{
    public class RaspodjelaPosla
    {
        public int Id { get; set; }
        public DateTime PocetakRada { get; set; }
        public DateTime? KrajRada { get; set; }
        public string Opis { get; set; }
        public int RadnikId { get; set; }
        public virtual Radnici Radnik { get; set; }
        public int GradilisteId { get; set; }
        public virtual Gradiliste Gradiliste { get; set; }
        public int TipPoslaId { get; set; }
        public virtual TipPosla TipPosla { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnici Korisnik { get; set; }
    }
}
