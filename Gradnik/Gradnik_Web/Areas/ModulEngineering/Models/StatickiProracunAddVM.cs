using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulEngineering.Models
{
    public class StatickiProracunAddVM
    {

        public string Opis { get; set; }
        public string Proracun { get; set; }
        public int TehnickiOpisId { get; set; }
        public List<int> FazeId { get; set; }
        public int OdabranaFazaId { get; set; }
        public int StatickiProracunId { get; set; }

        public List<StatickiProracunMaterijaliVM> ProracunMaterijali { get; set; }
        public int MaterijalId { get; set; }
        public List<SelectListItem> listaMaterijala;
        public int Kolicina { get; set; }
        public List<OdradeneFaze> odradeneFaze { get; set; }
        public int trenutnaFaza { get; set; }


    }

    public class StatickiProracunMaterijaliVM
    {
        public string Materijal { get; set; }
        public int MaterijalId { get; set; }
        public int Količina { get; set; }
    }

    public class OdradeneFaze
    {
        public int fazaId { get; set; }
        public bool isOdradene { get; set; }
    }
}