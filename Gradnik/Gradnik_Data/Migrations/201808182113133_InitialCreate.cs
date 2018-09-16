namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dobavljacis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                        Email = c.String(),
                        KontaktTelefon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fazes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gradilistes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazivProjekta = c.String(),
                        Lokacija = c.String(),
                        Trajanje = c.String(),
                        Investitor = c.String(),
                        ProjektiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projektis", t => t.ProjektiId)
                .Index(t => t.ProjektiId);
            
            CreateTable(
                "dbo.Projektis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Lokacija = c.String(),
                        DatumUgovora = c.DateTime(nullable: false),
                        PocetakProjekta = c.DateTime(nullable: false),
                        KrajProjekta = c.DateTime(nullable: false),
                        status = c.String(),
                        InvestitorId = c.Int(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                        ProjektnaDokumentacijaId = c.Int(),
                        TehnickiOpisId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Investitoris", t => t.InvestitorId)
                .ForeignKey("dbo.Korisnicis", t => t.KorisnikId)
                .ForeignKey("dbo.ProjektnaDokumentacijas", t => t.ProjektnaDokumentacijaId)
                .ForeignKey("dbo.TehnickiOpisis", t => t.TehnickiOpisId)
                .Index(t => t.InvestitorId)
                .Index(t => t.KorisnikId)
                .Index(t => t.ProjektnaDokumentacijaId)
                .Index(t => t.TehnickiOpisId);
            
            CreateTable(
                "dbo.Investitoris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        ImeOdgovorneOsobe = c.String(),
                        Adresa = c.String(),
                        KontaktTelefon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Korisnicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isActive = c.Boolean(nullable: false),
                        KorisnickoIme = c.String(),
                        Lozinka = c.String(),
                        Email = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        StrucnoZanimanje = c.String(),
                        Adresa = c.String(),
                        KontaktTelefon = c.String(),
                        isDirektor = c.Boolean(nullable: false),
                        isSefGradilista = c.Boolean(nullable: false),
                        isGradjevinskiIng = c.Boolean(nullable: false),
                        isArhitekta = c.Boolean(nullable: false),
                        isReferent = c.Boolean(nullable: false),
                        isAdmin = c.Boolean(nullable: false),
                        KorisnikPozicijaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KorisnikPozicijas", t => t.KorisnikPozicijaId)
                .Index(t => t.KorisnikPozicijaId);
            
            CreateTable(
                "dbo.KorisnikPozicijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjektnaDokumentacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Opis = c.String(),
                        CrtezPresjek = c.Binary(),
                        CrtezOsnova = c.Binary(),
                        CrtezKrov = c.Binary(),
                        CrtezFasada = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TehnickiOpisis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamjenaObjekta = c.String(),
                        Opis = c.String(),
                        Izvjestaj = c.String(),
                        OstaliRadovi = c.String(),
                        Odrzavanje = c.String(),
                        VijekTrajanja = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Izlazs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrojFakture = c.String(),
                        DatumKreiranja = c.DateTime(nullable: false),
                        ProjektId = c.Int(),
                        SkladisteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skladistes", t => t.SkladisteId)
                .ForeignKey("dbo.Projektis", t => t.ProjektId)
                .Index(t => t.ProjektId)
                .Index(t => t.SkladisteId);
            
            CreateTable(
                "dbo.IzlazStavkes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterijalId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        IzlazId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Izlazs", t => t.IzlazId)
                .ForeignKey("dbo.Materijals", t => t.MaterijalId)
                .Index(t => t.MaterijalId)
                .Index(t => t.IzlazId);
            
            CreateTable(
                "dbo.Materijals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NarudbzbaStavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterijalId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        NarudzbaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materijals", t => t.MaterijalId)
                .ForeignKey("dbo.Narudzbas", t => t.NarudzbaId)
                .Index(t => t.MaterijalId)
                .Index(t => t.NarudzbaId);
            
            CreateTable(
                "dbo.Narudzbas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KorisnikId = c.Int(nullable: false),
                        NarudzbaStatus = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisnicis", t => t.KorisnikId)
                .Index(t => t.KorisnikId);
            
            CreateTable(
                "dbo.Ulazs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrojFakture = c.String(),
                        Iznos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valuta = c.String(),
                        DatumKreiranja = c.DateTime(nullable: false),
                        DobavljacId = c.Int(),
                        NarudzbaId = c.Int(nullable: false),
                        SkladisteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dobavljacis", t => t.DobavljacId)
                .ForeignKey("dbo.Narudzbas", t => t.NarudzbaId)
                .ForeignKey("dbo.Skladistes", t => t.SkladisteId)
                .Index(t => t.DobavljacId)
                .Index(t => t.NarudzbaId)
                .Index(t => t.SkladisteId);
            
            CreateTable(
                "dbo.Skladistes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Lokacija = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UlazStavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterijalId = c.Int(nullable: false),
                        UlazId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materijals", t => t.MaterijalId)
                .ForeignKey("dbo.Ulazs", t => t.UlazId)
                .Index(t => t.MaterijalId)
                .Index(t => t.UlazId);
            
            CreateTable(
                "dbo.Izvjestajis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Izvjestaj = c.String(),
                        Datum = c.DateTime(nullable: false),
                        GradilisteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gradilistes", t => t.GradilisteId)
                .Index(t => t.GradilisteId);
            
            CreateTable(
                "dbo.Konstrukcijes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Karakteristike = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterijalDostupnis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Utroseno = c.Int(nullable: false),
                        Preostalo = c.Int(nullable: false),
                        NarudzbaMaterijalaId = c.Int(nullable: false),
                        GradilisteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gradilistes", t => t.GradilisteId)
                .Index(t => t.GradilisteId);
            
            CreateTable(
                "dbo.Radnicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        ImeRoditelja = c.String(),
                        JMBG = c.String(),
                        Spol = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        KontaktTelefon = c.String(),
                        Email = c.String(),
                        Grad = c.String(),
                        isZaduzen = c.Boolean(nullable: false),
                        Zvanje = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RaspodjelaPoslas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PocetakRada = c.DateTime(nullable: false),
                        KrajRada = c.DateTime(nullable: false),
                        Opis = c.String(),
                        RadnikId = c.Int(nullable: false),
                        GradilisteId = c.Int(nullable: false),
                        TipPoslaId = c.Int(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gradilistes", t => t.GradilisteId)
                .ForeignKey("dbo.Korisnicis", t => t.KorisnikId)
                .ForeignKey("dbo.Radnicis", t => t.RadnikId)
                .ForeignKey("dbo.TipPoslas", t => t.TipPoslaId)
                .Index(t => t.RadnikId)
                .Index(t => t.GradilisteId)
                .Index(t => t.TipPoslaId)
                .Index(t => t.KorisnikId);
            
            CreateTable(
                "dbo.TipPoslas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Satis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        isPlaceno = c.Boolean(nullable: false),
                        OdradjeniSati = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RaspodjelaPoslaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaspodjelaPoslas", t => t.RaspodjelaPoslaId)
                .Index(t => t.RaspodjelaPoslaId);
            
            CreateTable(
                "dbo.StatickiProracunis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Proracun = c.String(),
                        Opis = c.String(),
                        FazaId = c.Int(nullable: false),
                        TehnickiOpisiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fazes", t => t.FazaId)
                .ForeignKey("dbo.TehnickiOpisis", t => t.TehnickiOpisiId)
                .Index(t => t.FazaId)
                .Index(t => t.TehnickiOpisiId);
            
            CreateTable(
                "dbo.TehnologijaIzgradnjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Opis = c.String(),
                        KonstrukcijaId = c.Int(nullable: false),
                        TehnickiOpisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Konstrukcijes", t => t.KonstrukcijaId)
                .ForeignKey("dbo.TehnickiOpisis", t => t.TehnickiOpisId)
                .Index(t => t.KonstrukcijaId)
                .Index(t => t.TehnickiOpisId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TehnologijaIzgradnjes", "TehnickiOpisId", "dbo.TehnickiOpisis");
            DropForeignKey("dbo.TehnologijaIzgradnjes", "KonstrukcijaId", "dbo.Konstrukcijes");
            DropForeignKey("dbo.StatickiProracunis", "TehnickiOpisiId", "dbo.TehnickiOpisis");
            DropForeignKey("dbo.StatickiProracunis", "FazaId", "dbo.Fazes");
            DropForeignKey("dbo.Satis", "RaspodjelaPoslaId", "dbo.RaspodjelaPoslas");
            DropForeignKey("dbo.RaspodjelaPoslas", "TipPoslaId", "dbo.TipPoslas");
            DropForeignKey("dbo.RaspodjelaPoslas", "RadnikId", "dbo.Radnicis");
            DropForeignKey("dbo.RaspodjelaPoslas", "KorisnikId", "dbo.Korisnicis");
            DropForeignKey("dbo.RaspodjelaPoslas", "GradilisteId", "dbo.Gradilistes");
            DropForeignKey("dbo.MaterijalDostupnis", "GradilisteId", "dbo.Gradilistes");
            DropForeignKey("dbo.Izvjestajis", "GradilisteId", "dbo.Gradilistes");
            DropForeignKey("dbo.Izlazs", "ProjektId", "dbo.Projektis");
            DropForeignKey("dbo.UlazStavkas", "UlazId", "dbo.Ulazs");
            DropForeignKey("dbo.UlazStavkas", "MaterijalId", "dbo.Materijals");
            DropForeignKey("dbo.Ulazs", "SkladisteId", "dbo.Skladistes");
            DropForeignKey("dbo.Izlazs", "SkladisteId", "dbo.Skladistes");
            DropForeignKey("dbo.Ulazs", "NarudzbaId", "dbo.Narudzbas");
            DropForeignKey("dbo.Ulazs", "DobavljacId", "dbo.Dobavljacis");
            DropForeignKey("dbo.NarudbzbaStavkas", "NarudzbaId", "dbo.Narudzbas");
            DropForeignKey("dbo.Narudzbas", "KorisnikId", "dbo.Korisnicis");
            DropForeignKey("dbo.NarudbzbaStavkas", "MaterijalId", "dbo.Materijals");
            DropForeignKey("dbo.IzlazStavkes", "MaterijalId", "dbo.Materijals");
            DropForeignKey("dbo.IzlazStavkes", "IzlazId", "dbo.Izlazs");
            DropForeignKey("dbo.Gradilistes", "ProjektiId", "dbo.Projektis");
            DropForeignKey("dbo.Projektis", "TehnickiOpisId", "dbo.TehnickiOpisis");
            DropForeignKey("dbo.Projektis", "ProjektnaDokumentacijaId", "dbo.ProjektnaDokumentacijas");
            DropForeignKey("dbo.Projektis", "KorisnikId", "dbo.Korisnicis");
            DropForeignKey("dbo.Korisnicis", "KorisnikPozicijaId", "dbo.KorisnikPozicijas");
            DropForeignKey("dbo.Projektis", "InvestitorId", "dbo.Investitoris");
            DropIndex("dbo.TehnologijaIzgradnjes", new[] { "TehnickiOpisId" });
            DropIndex("dbo.TehnologijaIzgradnjes", new[] { "KonstrukcijaId" });
            DropIndex("dbo.StatickiProracunis", new[] { "TehnickiOpisiId" });
            DropIndex("dbo.StatickiProracunis", new[] { "FazaId" });
            DropIndex("dbo.Satis", new[] { "RaspodjelaPoslaId" });
            DropIndex("dbo.RaspodjelaPoslas", new[] { "KorisnikId" });
            DropIndex("dbo.RaspodjelaPoslas", new[] { "TipPoslaId" });
            DropIndex("dbo.RaspodjelaPoslas", new[] { "GradilisteId" });
            DropIndex("dbo.RaspodjelaPoslas", new[] { "RadnikId" });
            DropIndex("dbo.MaterijalDostupnis", new[] { "GradilisteId" });
            DropIndex("dbo.Izvjestajis", new[] { "GradilisteId" });
            DropIndex("dbo.UlazStavkas", new[] { "UlazId" });
            DropIndex("dbo.UlazStavkas", new[] { "MaterijalId" });
            DropIndex("dbo.Ulazs", new[] { "SkladisteId" });
            DropIndex("dbo.Ulazs", new[] { "NarudzbaId" });
            DropIndex("dbo.Ulazs", new[] { "DobavljacId" });
            DropIndex("dbo.Narudzbas", new[] { "KorisnikId" });
            DropIndex("dbo.NarudbzbaStavkas", new[] { "NarudzbaId" });
            DropIndex("dbo.NarudbzbaStavkas", new[] { "MaterijalId" });
            DropIndex("dbo.IzlazStavkes", new[] { "IzlazId" });
            DropIndex("dbo.IzlazStavkes", new[] { "MaterijalId" });
            DropIndex("dbo.Izlazs", new[] { "SkladisteId" });
            DropIndex("dbo.Izlazs", new[] { "ProjektId" });
            DropIndex("dbo.Korisnicis", new[] { "KorisnikPozicijaId" });
            DropIndex("dbo.Projektis", new[] { "TehnickiOpisId" });
            DropIndex("dbo.Projektis", new[] { "ProjektnaDokumentacijaId" });
            DropIndex("dbo.Projektis", new[] { "KorisnikId" });
            DropIndex("dbo.Projektis", new[] { "InvestitorId" });
            DropIndex("dbo.Gradilistes", new[] { "ProjektiId" });
            DropTable("dbo.TehnologijaIzgradnjes");
            DropTable("dbo.StatickiProracunis");
            DropTable("dbo.Satis");
            DropTable("dbo.TipPoslas");
            DropTable("dbo.RaspodjelaPoslas");
            DropTable("dbo.Radnicis");
            DropTable("dbo.MaterijalDostupnis");
            DropTable("dbo.Konstrukcijes");
            DropTable("dbo.Izvjestajis");
            DropTable("dbo.UlazStavkas");
            DropTable("dbo.Skladistes");
            DropTable("dbo.Ulazs");
            DropTable("dbo.Narudzbas");
            DropTable("dbo.NarudbzbaStavkas");
            DropTable("dbo.Materijals");
            DropTable("dbo.IzlazStavkes");
            DropTable("dbo.Izlazs");
            DropTable("dbo.TehnickiOpisis");
            DropTable("dbo.ProjektnaDokumentacijas");
            DropTable("dbo.KorisnikPozicijas");
            DropTable("dbo.Korisnicis");
            DropTable("dbo.Investitoris");
            DropTable("dbo.Projektis");
            DropTable("dbo.Gradilistes");
            DropTable("dbo.Fazes");
            DropTable("dbo.Dobavljacis");
        }
    }
}
