namespace WhatsIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Store : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Address1", c => c.String());
            AddColumn("dbo.Stores", "Address2", c => c.String());
            AddColumn("dbo.Stores", "Town", c => c.String());
            AddColumn("dbo.Stores", "PostalCode", c => c.String());
            AddColumn("dbo.Stores", "FacebookPage", c => c.String());
            AddColumn("dbo.Stores", "TwitterPage", c => c.String());
            AddColumn("dbo.Stores", "InstagramPage", c => c.String());
            DropColumn("dbo.Stores", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "Address", c => c.String());
            DropColumn("dbo.Stores", "InstagramPage");
            DropColumn("dbo.Stores", "TwitterPage");
            DropColumn("dbo.Stores", "FacebookPage");
            DropColumn("dbo.Stores", "PostalCode");
            DropColumn("dbo.Stores", "Town");
            DropColumn("dbo.Stores", "Address2");
            DropColumn("dbo.Stores", "Address1");
        }
    }
}
