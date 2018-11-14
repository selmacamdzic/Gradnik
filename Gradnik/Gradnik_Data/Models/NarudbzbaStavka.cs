namespace Gradnik_Data.Models
{
    public class NarudbzbaStavka
    {
        public int Id { get; set; }
        public virtual Materijal Materijal { get; set; }
        public int MaterijalId { get; set; }
        public int Kolicina { get; set; }
        public virtual Narudzba Narudzba{ get; set; }
        public int NarudzbaId { get; set; }
    }
}