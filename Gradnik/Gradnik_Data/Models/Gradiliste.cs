namespace Gradnik_Data.Models
{
    public class Gradiliste
    {
        public int Id { get; set; }
        public string Grad { get; set; }
        public string Opstina { get; set; }
        public string PostanskiBroj { get; set; }
        public string Adresa { get; set; }
        public int ProjektiId { get; set; }
        public virtual Projekti Projekti { get; set; }
    }
}
