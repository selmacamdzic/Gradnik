namespace Gradnik_Data.Models
{
    public class IzlazStavke
    {
        public int Id { get; set; }
        public int MaterijalId { get; set; }
        public int Kolicina { get; set; }
        public virtual Materijal Materijal { get; set; }
        public virtual Izlaz Izlaz { get; set; }
        public int IzlazId { get; set; }
    }
}