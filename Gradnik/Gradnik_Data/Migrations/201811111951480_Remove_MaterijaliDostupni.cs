namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_MaterijaliDostupni : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterijalDostupnis", "GradilisteId", "dbo.Gradilistes");
            DropForeignKey("dbo.Izlazs", "MaterijalDostupni_Id", "dbo.MaterijalDostupnis");
            DropIndex("dbo.Izlazs", new[] { "MaterijalDostupni_Id" });
            DropIndex("dbo.MaterijalDostupnis", new[] { "GradilisteId" });
            DropColumn("dbo.Izlazs", "MaterijalDostupni_Id");
            DropTable("dbo.MaterijalDostupnis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MaterijalDostupnis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GradilisteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Izlazs", "MaterijalDostupni_Id", c => c.Int());
            CreateIndex("dbo.MaterijalDostupnis", "GradilisteId");
            CreateIndex("dbo.Izlazs", "MaterijalDostupni_Id");
            AddForeignKey("dbo.Izlazs", "MaterijalDostupni_Id", "dbo.MaterijalDostupnis", "Id");
            AddForeignKey("dbo.MaterijalDostupnis", "GradilisteId", "dbo.Gradilistes", "Id");
        }
    }
}
