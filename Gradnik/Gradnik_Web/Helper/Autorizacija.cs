using Gradnik_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Helper
{
    public class Autorizacija : FilterAttribute, IAuthorizationFilter
    {
        private readonly bool IsAdmin;
        private readonly bool IsDirektor;



        public Autorizacija(bool isAdmin, bool isDirektor)
        {
            IsAdmin=isAdmin;
            IsDirektor = isDirektor;

        }

     

        public void OnAuthorization(AuthorizationContext filter)
        {
            Korisnici PrijavljeniKorisnik = Autentifikacija.GetLogiraniKorisnik(filter.HttpContext);

            bool pristupOdobren = false;

            if (PrijavljeniKorisnik != null)
            {
                if (PrijavljeniKorisnik.isAdmin)
                    pristupOdobren = true;

                if (PrijavljeniKorisnik.isDirektor)             
                    pristupOdobren = true;

                

                //if ((PrijavljeniKorisnik.Zaposlenik != null) && (PrijavljeniKorisnik.Zaposlenik.IsModerator) && (IsModerator))
                //    pristupOdobren = true;

                //if ((PrijavljeniKorisnik.Zaposlenik != null) && (PrijavljeniKorisnik.Zaposlenik.IsRadnik) && (IsRadnik))
                //    pristupOdobren = true;

                //if ((PrijavljeniKorisnik.Klijent != null) && (IsKlijent))
                //    pristupOdobren = true;
            }

            if (!pristupOdobren)
                filter.HttpContext.Response.Redirect("/Home/Index");


        }
    }
}