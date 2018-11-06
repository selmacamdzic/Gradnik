using System.Web;

namespace Gradnik_Web.Areas.ModulEngineering.Models
{
    public class ProjektnaDokumentacijaAddVM
    {
        public int ProjekatId { get; set; }
        public string Opis { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}