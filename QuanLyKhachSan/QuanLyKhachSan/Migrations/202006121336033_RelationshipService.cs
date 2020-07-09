namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipService : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceProducts", "ServiceID", "dbo.Services");
            DropIndex("dbo.ServiceProducts", new[] { "ServiceID" });
            AddColumn("dbo.Revervations", "ServiceID", c => c.Int());
            AddColumn("dbo.Revervations", "Service_ServiceID", c => c.Int());
            AddColumn("dbo.Services", "ProductID", c => c.Int());
            CreateIndex("dbo.Revervations", "ServiceID");
            CreateIndex("dbo.Revervations", "Service_ServiceID");
            CreateIndex("dbo.Services", "ProductID");
            AddForeignKey("dbo.Revervations", "Service_ServiceID", "dbo.Services", "ServiceID");
            AddForeignKey("dbo.Services", "ProductID", "dbo.ServiceProducts", "ProductID");
            AddForeignKey("dbo.Revervations", "ServiceID", "dbo.Services", "ServiceID");
            DropColumn("dbo.ServiceProducts", "ServiceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceProducts", "ServiceID", c => c.Int());
            DropForeignKey("dbo.Revervations", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "ProductID", "dbo.ServiceProducts");
            DropForeignKey("dbo.Revervations", "Service_ServiceID", "dbo.Services");
            DropIndex("dbo.Services", new[] { "ProductID" });
            DropIndex("dbo.Revervations", new[] { "Service_ServiceID" });
            DropIndex("dbo.Revervations", new[] { "ServiceID" });
            DropColumn("dbo.Services", "ProductID");
            DropColumn("dbo.Revervations", "Service_ServiceID");
            DropColumn("dbo.Revervations", "ServiceID");
            CreateIndex("dbo.ServiceProducts", "ServiceID");
            AddForeignKey("dbo.ServiceProducts", "ServiceID", "dbo.Services", "ServiceID");
        }
    }
}
