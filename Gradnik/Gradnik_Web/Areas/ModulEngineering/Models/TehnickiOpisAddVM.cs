using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulEngineering.Models
{
    public class TehnickiOpisAddVM
    {
     
        [Required]
        public string NamjenaObjekta { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public string Izvjestaj { get; set; }
        public string OstaliRadovi { get; set; }
        public string Odrzavanje { get; set; }
        [Required]
        public string VijekTrajanja { get; set; }
        public int ProjektId { get; set; }

        [Required]
        public List<int> FazeId { get; set; }
        public List<SelectListItem> listaFaza;
    }
}