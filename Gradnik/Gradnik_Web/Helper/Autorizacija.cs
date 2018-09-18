using Gradnik_Data.Models;
using System.Web.Mvc;

namespace Gradnik_Web.Helper
{
    public class Autorizacija : FilterAttribute, IAuthorizationFilter
    {
        private readonly KorisnikUloga Uloga;

        public Autorizacija(KorisnikUloga uloga)
        {
            Uloga = uloga;
        }

        public void OnAuthorization(AuthorizationContext filter)
        {
            Korisnici PrijavljeniKorisnik = Autentifikacija.GetLogiraniKorisnik(filter.HttpContext);
            bool pristupOdobren = false;

            if (PrijavljeniKorisnik != null)
            {
                if (PrijavljeniKorisnik.KorisnikUloga == Uloga)
                    pristupOdobren = true;
                else
                    pristupOdobren = false;
            }

            if (!pristupOdobren)
                filter.HttpContext.Response.Redirect("/Home/Index");
        }
    }
}