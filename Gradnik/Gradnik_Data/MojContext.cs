using Gradnik_Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gradnik_Data
{
    public class MojContext:DbContext
    {
        public MojContext() : base("name=MojConnectionString")
        { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Dobavljaci> Dobavljaci { get; set; }
        public DbSet<Gradiliste> Gradiliste { get; set; }
        public DbSet<Investitori> Investitori { get; set; }
        public DbSet<Izvjestaji> Izvjestaji { get; set; }
        public DbSet<Korisnici> Korisnici { get; set; }
        public DbSet<MaterijalDostupni> MaterijalDostupni { get; set; }
        public DbSet<Materijal> Materijali { get; set; }
        public DbSet<Projekti> Projekti { get; set; }
        public DbSet<Radnici> Radnici { get; set; }
        public DbSet<RaspodjelaPosla> RaspodjelaPosla { get; set; }
        public DbSet<Sati> Sati { get; set; }
        public DbSet<TipPosla> TipPosla { get; set; }
        public DbSet<Ulaz> Ulaz { get; set; }
        public DbSet<UlazStavka> UlazStavka { get; set; }
        public DbSet<Izlaz> Izlaz { get; set; }
        public DbSet<IzlazStavke> IzlazStavke { get; set; }
        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<NarudbzbaStavka> NarudbzbaStavka { get; set; }
        public DbSet<Skladiste> Skladista { get; set; }
        public DbSet<Dokumentacija> Dokumentacija { get; set; }

    }
}
