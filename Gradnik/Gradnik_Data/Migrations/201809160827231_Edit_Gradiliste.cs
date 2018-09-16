namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Gradiliste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gradilistes", "Grad", c => c.String());
            AddColumn("dbo.Gradilistes", "Opstina", c => c.String());
            AddColumn("dbo.Gradilistes", "PostanskiBroj", c => c.String());
            AddColumn("dbo.Gradilistes", "Adresa", c => c.String());
            DropColumn("dbo.Gradilistes", "NazivProjekta");
            DropColumn("dbo.Gradilistes", "Lokacija");
            DropColumn("dbo.Gradilistes", "Trajanje");
            DropColumn("dbo.Gradilistes", "Investitor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gradilistes", "Investitor", c => c.String());
            AddColumn("dbo.Gradilistes", "Trajanje", c => c.String());
            AddColumn("dbo.Gradilistes", "Lokacija", c => c.String());
            AddColumn("dbo.Gradilistes", "NazivProjekta", c => c.String());
            DropColumn("dbo.Gradilistes", "Adresa");
            DropColumn("dbo.Gradilistes", "PostanskiBroj");
            DropColumn("dbo.Gradilistes", "Opstina");
            DropColumn("dbo.Gradilistes", "Grad");
        }
    }
}
