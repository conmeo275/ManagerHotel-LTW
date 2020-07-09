namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditFollowKhoa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "ReverID", "dbo.Revervations");
            DropForeignKey("dbo.Revervations", "Service_ServiceID", "dbo.Services");
            DropForeignKey("dbo.ServiceProducts", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "ServiceProduct_ProductID", "dbo.ServiceProducts");
            DropForeignKey("dbo.ServiceProducts", "Service_ServiceID", "dbo.Services");
            DropIndex("dbo.Revervations", new[] { "Service_ServiceID" });
            DropIndex("dbo.Services", new[] { "ReverID" });
            DropIndex("dbo.Services", new[] { "ServiceProduct_ProductID" });
            DropIndex("dbo.ServiceProducts", new[] { "ServiceID" });
            DropIndex("dbo.ServiceProducts", new[] { "Service_ServiceID" });
            DropColumn("dbo.Revervations", "Service_ServiceID");
            DropColumn("dbo.Services", "ReverID");
            DropColumn("dbo.Services", "ServiceProduct_ProductID");
            DropColumn("dbo.ServiceProducts", "ServiceID");
            DropColumn("dbo.ServiceProducts", "Service_ServiceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceProducts", "Service_ServiceID", c => c.Int());
            AddColumn("dbo.ServiceProducts", "ServiceID", c => c.Int());
            AddColumn("dbo.Services", "ServiceProduct_ProductID", c => c.Int());
            AddColumn("dbo.Services", "ReverID", c => c.Int());
            AddColumn("dbo.Revervations", "Service_ServiceID", c => c.Int());
            CreateIndex("dbo.ServiceProducts", "Service_ServiceID");
            CreateIndex("dbo.ServiceProducts", "ServiceID");
            CreateIndex("dbo.Services", "ServiceProduct_ProductID");
            CreateIndex("dbo.Services", "ReverID");
            CreateIndex("dbo.Revervations", "Service_ServiceID");
            AddForeignKey("dbo.ServiceProducts", "Service_ServiceID", "dbo.Services", "ServiceID");
            AddForeignKey("dbo.Services", "ServiceProduct_ProductID", "dbo.ServiceProducts", "ProductID");
            AddForeignKey("dbo.ServiceProducts", "ServiceID", "dbo.Services", "ServiceID");
            AddForeignKey("dbo.Revervations", "Service_ServiceID", "dbo.Services", "ServiceID");
            AddForeignKey("dbo.Services", "ReverID", "dbo.Revervations", "ReverID");
        }
    }
}
