namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_ProjektStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projektis", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projektis", "Status", c => c.String());
        }
    }
}
