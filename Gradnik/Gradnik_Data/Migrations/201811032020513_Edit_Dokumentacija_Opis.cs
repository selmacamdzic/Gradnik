namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Dokumentacija_Opis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dokumentacijas", "Opis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dokumentacijas", "Opis");
        }
    }
}
