namespace Gradnik_Api.Models
{
    public class TipPoslovaPoGradilistuVM
    {
        public int RadnikId { get; set; }
        public int ProjekatId { get; set; }
        public int TipPoslaId { get; set; }
        public string TipPoslaNaziv { get; set; }
        public int count { get; set; }
    }
}