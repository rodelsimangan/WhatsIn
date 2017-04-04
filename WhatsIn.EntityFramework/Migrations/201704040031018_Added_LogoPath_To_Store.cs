namespace WhatsIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_LogoPath_To_Store : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "LogoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "LogoPath");
        }
    }
}
