using System.Collections.Generic;

namespace Gradnik_Data.Models
{
    public class MaterijalDostupni
    {
        public int Id { get; set; }
        public int GradilisteId { get; set; }
        public virtual Gradiliste Gradiliste { get; set; }
        public List<Izlaz> Izlaz { get; set; }
    }
}
