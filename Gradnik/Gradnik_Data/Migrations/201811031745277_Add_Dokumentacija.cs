namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Dokumentacija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dokumentacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Datum = c.DateTime(nullable: false),
                        File = c.Binary(),
                        ProjekatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projektis", t => t.ProjekatId)
                .Index(t => t.ProjekatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dokumentacijas", "ProjekatId", "dbo.Projektis");
            DropIndex("dbo.Dokumentacijas", new[] { "ProjekatId" });
            DropTable("dbo.Dokumentacijas");
        }
    }
}
