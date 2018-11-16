namespace Gradnik_Api.Models
{
    public class DodajRadnikaVM
    {
        public int jobTypeId { get; set; }
        public int[] selectedEmployees { get; set; }
        public int projektId { get; set; }
    }
}