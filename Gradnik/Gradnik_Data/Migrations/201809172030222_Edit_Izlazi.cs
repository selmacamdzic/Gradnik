namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Izlazi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Izlazs", "ProjektId", "dbo.Projektis");
            DropIndex("dbo.Izlazs", new[] { "ProjektId" });
            AddColumn("dbo.Izlazs", "GradilisteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Izlazs", "GradilisteId");
            AddForeignKey("dbo.Izlazs", "GradilisteId", "dbo.Gradilistes", "Id");
            DropColumn("dbo.Izlazs", "ProjektId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Izlazs", "ProjektId", c => c.Int());
            DropForeignKey("dbo.Izlazs", "GradilisteId", "dbo.Gradilistes");
            DropIndex("dbo.Izlazs", new[] { "GradilisteId" });
            DropColumn("dbo.Izlazs", "GradilisteId");
            CreateIndex("dbo.Izlazs", "ProjektId");
            AddForeignKey("dbo.Izlazs", "ProjektId", "dbo.Projektis", "Id");
        }
    }
}
