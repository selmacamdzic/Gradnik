namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_Staticke_Proracune : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projektis", "TehnickiOpisId", "dbo.TehnickiOpisis");
            DropForeignKey("dbo.StatickiProracunis", "FazaId", "dbo.Fazes");
            DropForeignKey("dbo.StatickiProracunis", "TehnickiOpisiId", "dbo.TehnickiOpisis");
            DropForeignKey("dbo.TehnologijaIzgradnjes", "KonstrukcijaId", "dbo.Konstrukcijes");
            DropForeignKey("dbo.TehnologijaIzgradnjes", "TehnickiOpisId", "dbo.TehnickiOpisis");
            DropIndex("dbo.Projektis", new[] { "TehnickiOpisId" });
            DropIndex("dbo.StatickiProracunis", new[] { "FazaId" });
            DropIndex("dbo.StatickiProracunis", new[] { "TehnickiOpisiId" });
            DropIndex("dbo.TehnologijaIzgradnjes", new[] { "KonstrukcijaId" });
            DropIndex("dbo.TehnologijaIzgradnjes", new[] { "TehnickiOpisId" });
            DropColumn("dbo.Projektis", "TehnickiOpisId");
            DropTable("dbo.Fazes");
            DropTable("dbo.TehnickiOpisis");
            DropTable("dbo.Konstrukcijes");
            DropTable("dbo.StatickiProracunis");
            DropTable("dbo.TehnologijaIzgradnjes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TehnologijaIzgradnjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Opis = c.String(),
                        KonstrukcijaId = c.Int(nullable: false),
                        TehnickiOpisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Fazes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Projektis", "TehnickiOpisId", c => c.Int());
            CreateIndex("dbo.TehnologijaIzgradnjes", "TehnickiOpisId");
            CreateIndex("dbo.TehnologijaIzgradnjes", "KonstrukcijaId");
            CreateIndex("dbo.StatickiProracunis", "TehnickiOpisiId");
            CreateIndex("dbo.StatickiProracunis", "FazaId");
            CreateIndex("dbo.Projektis", "TehnickiOpisId");
            AddForeignKey("dbo.TehnologijaIzgradnjes", "TehnickiOpisId", "dbo.TehnickiOpisis", "Id");
            AddForeignKey("dbo.TehnologijaIzgradnjes", "KonstrukcijaId", "dbo.Konstrukcijes", "Id");
            AddForeignKey("dbo.StatickiProracunis", "TehnickiOpisiId", "dbo.TehnickiOpisis", "Id");
            AddForeignKey("dbo.StatickiProracunis", "FazaId", "dbo.Fazes", "Id");
            AddForeignKey("dbo.Projektis", "TehnickiOpisId", "dbo.TehnickiOpisis", "Id");
        }
    }
}
