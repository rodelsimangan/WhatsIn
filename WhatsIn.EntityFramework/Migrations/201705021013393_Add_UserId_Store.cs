namespace WhatsIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UserId_Store : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "UserId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "UserId");
        }
    }
}
