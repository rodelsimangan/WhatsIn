namespace WhatsIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Gallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        GalleryPath = c.String(),
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
            DropTable("dbo.Galleries");
        }
    }
}
