namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_MaterijalDostupni : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Izlazs", "MaterijalDostupni_Id", c => c.Int());
            CreateIndex("dbo.Izlazs", "MaterijalDostupni_Id");
            AddForeignKey("dbo.Izlazs", "MaterijalDostupni_Id", "dbo.MaterijalDostupnis", "Id");
            DropColumn("dbo.MaterijalDostupnis", "Utroseno");
            DropColumn("dbo.MaterijalDostupnis", "Preostalo");
            DropColumn("dbo.MaterijalDostupnis", "NarudzbaMaterijalaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterijalDostupnis", "NarudzbaMaterijalaId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterijalDostupnis", "Preostalo", c => c.Int(nullable: false));
            AddColumn("dbo.MaterijalDostupnis", "Utroseno", c => c.Int(nullable: false));
            DropForeignKey("dbo.Izlazs", "MaterijalDostupni_Id", "dbo.MaterijalDostupnis");
            DropIndex("dbo.Izlazs", new[] { "MaterijalDostupni_Id" });
            DropColumn("dbo.Izlazs", "MaterijalDostupni_Id");
        }
    }
}
