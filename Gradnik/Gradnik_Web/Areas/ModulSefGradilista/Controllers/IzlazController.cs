using Gradnik_Data;
using Gradnik_Data.Models;
using Gradnik_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    [Autorizacija(KorisnikUloga.SefGradilista)]
    public class IzlazController : Controller
    {
        // GET: ModulSefGradilista/Izlaz

        MojContext context = new MojContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}