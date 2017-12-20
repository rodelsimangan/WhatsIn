namespace WhatsIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Store_Logo_Promotion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        LogoPath = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        DateCreated = c.DateTime(),
                        ModifiedBy = c.Long(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        PromotionPath = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        DateCreated = c.DateTime(),
                        ModifiedBy = c.Long(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ContactNum = c.String(),
                        Address = c.String(),
                        LocationId = c.Int(nullable: false),
                        Email = c.String(),
                        Schedule = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.Long(),
                        DateCreated = c.DateTime(),
                        ModifiedBy = c.Long(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stores");
            DropTable("dbo.Promotions");
            DropTable("dbo.Logo");
        }
    }
}
