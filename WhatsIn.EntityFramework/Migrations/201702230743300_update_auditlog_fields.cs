namespace WhatsIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_auditlog_fields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CreatedBy", c => c.Long());
            AlterColumn("dbo.Categories", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Categories", "ModifiedBy", c => c.Long());
            AlterColumn("dbo.Categories", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Locations", "CreatedBy", c => c.Long());
            AlterColumn("dbo.Locations", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Locations", "ModifiedBy", c => c.Long());
            AlterColumn("dbo.Locations", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Provinces", "CreatedBy", c => c.Long());
            AlterColumn("dbo.Provinces", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Provinces", "ModifiedBy", c => c.Long());
            AlterColumn("dbo.Provinces", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Provinces", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Provinces", "ModifiedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Provinces", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Provinces", "CreatedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Locations", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "ModifiedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Locations", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "CreatedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Categories", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "ModifiedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Categories", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedBy", c => c.Long(nullable: false));
        }
    }
}
