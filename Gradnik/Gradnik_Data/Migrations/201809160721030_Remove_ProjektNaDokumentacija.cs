namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_ProjektNaDokumentacija : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projektis", "ProjektnaDokumentacijaId", "dbo.ProjektnaDokumentacijas");
            DropIndex("dbo.Projektis", new[] { "ProjektnaDokumentacijaId" });
            DropColumn("dbo.Projektis", "ProjektnaDokumentacijaId");
            DropTable("dbo.ProjektnaDokumentacijas");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Projektis", "ProjektnaDokumentacijaId", c => c.Int());
            CreateIndex("dbo.Projektis", "ProjektnaDokumentacijaId");
            AddForeignKey("dbo.Projektis", "ProjektnaDokumentacijaId", "dbo.ProjektnaDokumentacijas", "Id");
        }
    }
}
