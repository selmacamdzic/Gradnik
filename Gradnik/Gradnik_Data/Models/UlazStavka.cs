namespace Gradnik_Data.Models
{
    public class UlazStavka
    {
        public int Id { get; set; }
        public virtual Materijal Materijal { get; set; }
        public virtual Ulaz Ulaz { get; set; }
        public int MaterijalId { get; set; }
        public int UlazId { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
    }
}