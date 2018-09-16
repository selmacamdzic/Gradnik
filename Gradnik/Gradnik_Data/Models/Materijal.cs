using System.Collections.Generic;

namespace Gradnik_Data.Models
{
    public class Materijal
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public List<UlazStavka> UlazStavka { get; set; }
        public List<IzlazStavke> IzlazStavka { get; set; }
        public List<NarudbzbaStavka> NarudbzbaStavka { get; set; }
    }
}