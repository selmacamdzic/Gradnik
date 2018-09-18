namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_KorisnikUloge : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Korisnicis", "KorisnikPozicijaId", "dbo.KorisnikPozicijas");
            DropIndex("dbo.Korisnicis", new[] { "KorisnikPozicijaId" });
            AddColumn("dbo.Korisnicis", "KorisnikUloga", c => c.Int(nullable: false));
            DropColumn("dbo.Korisnicis", "isDirektor");
            DropColumn("dbo.Korisnicis", "isSefGradilista");
            DropColumn("dbo.Korisnicis", "isGradjevinskiIng");
            DropColumn("dbo.Korisnicis", "isArhitekta");
            DropColumn("dbo.Korisnicis", "isReferent");
            DropColumn("dbo.Korisnicis", "isAdmin");
            DropColumn("dbo.Korisnicis", "KorisnikPozicijaId");
            DropTable("dbo.KorisnikPozicijas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.KorisnikPozicijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Korisnicis", "KorisnikPozicijaId", c => c.Int(nullable: false));
            AddColumn("dbo.Korisnicis", "isAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Korisnicis", "isReferent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Korisnicis", "isArhitekta", c => c.Boolean(nullable: false));
            AddColumn("dbo.Korisnicis", "isGradjevinskiIng", c => c.Boolean(nullable: false));
            AddColumn("dbo.Korisnicis", "isSefGradilista", c => c.Boolean(nullable: false));
            AddColumn("dbo.Korisnicis", "isDirektor", c => c.Boolean(nullable: false));
            DropColumn("dbo.Korisnicis", "KorisnikUloga");
            CreateIndex("dbo.Korisnicis", "KorisnikPozicijaId");
            AddForeignKey("dbo.Korisnicis", "KorisnikPozicijaId", "dbo.KorisnikPozicijas", "Id");
        }
    }
}
