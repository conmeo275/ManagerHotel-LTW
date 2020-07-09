namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edittest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "ReverID", "dbo.Revervations");
            DropForeignKey("dbo.Revervations", "Service_ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "ProductID", "dbo.ServiceProducts");
            DropForeignKey("dbo.Revervations", "ServiceID", "dbo.Services");
            DropIndex("dbo.Revervations", new[] { "ServiceID" });
            DropIndex("dbo.Revervations", new[] { "Service_ServiceID" });
            DropIndex("dbo.Services", new[] { "ReverID" });
            DropIndex("dbo.Services", new[] { "ProductID" });
            AddColumn("dbo.ServiceProducts", "ServiceID", c => c.Int());
            CreateIndex("dbo.ServiceProducts", "ServiceID");
            AddForeignKey("dbo.ServiceProducts", "ServiceID", "dbo.Services", "ServiceID");
            DropColumn("dbo.Revervations", "ServiceID");
            DropColumn("dbo.Revervations", "Service_ServiceID");
            DropColumn("dbo.Services", "ReverID");
            DropColumn("dbo.Services", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "ProductID", c => c.Int());
            AddColumn("dbo.Services", "ReverID", c => c.Int());
            AddColumn("dbo.Revervations", "Service_ServiceID", c => c.Int());
            AddColumn("dbo.Revervations", "ServiceID", c => c.Int());
            DropForeignKey("dbo.ServiceProducts", "ServiceID", "dbo.Services");
            DropIndex("dbo.ServiceProducts", new[] { "ServiceID" });
            DropColumn("dbo.ServiceProducts", "ServiceID");
            CreateIndex("dbo.Services", "ProductID");
            CreateIndex("dbo.Services", "ReverID");
            CreateIndex("dbo.Revervations", "Service_ServiceID");
            CreateIndex("dbo.Revervations", "ServiceID");
            AddForeignKey("dbo.Revervations", "ServiceID", "dbo.Services", "ServiceID");
            AddForeignKey("dbo.Services", "ProductID", "dbo.ServiceProducts", "ProductID");
            AddForeignKey("dbo.Revervations", "Service_ServiceID", "dbo.Services", "ServiceID");
            AddForeignKey("dbo.Services", "ReverID", "dbo.Revervations", "ReverID");
        }
    }
}
