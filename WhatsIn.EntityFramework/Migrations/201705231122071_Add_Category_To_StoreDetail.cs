namespace WhatsIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Category_To_StoreDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "CategoryId");
        }
    }
}
