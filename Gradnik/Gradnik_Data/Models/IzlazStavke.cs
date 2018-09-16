namespace Gradnik_Data.Models
{
    public class IzlazStavke
    {
        public int Id { get; set; }
        public int MaterijalId { get; set; }
        public int Kolicina { get; set; }
        public Materijal Materijal { get; set; }
        public Izlaz Izlaz { get; set; }
        public int IzlazId { get; set; }
    }
}