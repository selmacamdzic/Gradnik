namespace Gradnik_Web.Models
{
    public class StanjeSkladistaDto
    {
        public int SkladisteId { get; set; }
        public string Skladiste { get; set; }
        public int MaterijalId { get; set; }
        public string Materijal { get; set; }
        public int Dostupno { get; set; }
    }
}