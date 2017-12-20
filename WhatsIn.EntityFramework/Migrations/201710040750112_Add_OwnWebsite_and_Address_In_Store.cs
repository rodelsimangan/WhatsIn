namespace WhatsIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_OwnWebsite_and_Address_In_Store : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "HasOwnWebsite", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stores", "WebsiteAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "WebsiteAddress");
            DropColumn("dbo.Stores", "HasOwnWebsite");
        }
    }
}
