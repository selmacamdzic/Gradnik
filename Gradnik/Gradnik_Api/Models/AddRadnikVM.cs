namespace Gradnik_Api.Models
{
    public class AddRadnikVM
    {
        public int JobTypeId { get; set; }
        public int[] SelectedEmployees { get; set; }
    }
}