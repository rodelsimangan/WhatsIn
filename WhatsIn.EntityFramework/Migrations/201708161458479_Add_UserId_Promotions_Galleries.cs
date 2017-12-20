namespace WhatsIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UserId_Promotions_Galleries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "UserId", c => c.Long(nullable: false));
            AddColumn("dbo.Promotions", "UserId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promotions", "UserId");
            DropColumn("dbo.Galleries", "UserId");
        }
    }
}
