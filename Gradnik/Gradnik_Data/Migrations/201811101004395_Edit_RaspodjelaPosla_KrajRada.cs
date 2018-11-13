namespace Gradnik_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_RaspodjelaPosla_KrajRada : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RaspodjelaPoslas", "KrajRada", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RaspodjelaPoslas", "KrajRada", c => c.DateTime(nullable: false));
        }
    }
}
