namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditSerAndSerPro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceProducts", "ServiceID", "dbo.Services");
            AddColumn("dbo.Services", "ProductID", c => c.Int());
            AddColumn("dbo.Services", "ServiceProduct_ProductID", c => c.Int());
            AddColumn("dbo.ServiceProducts", "Service_ServiceID", c => c.Int());
            CreateIndex("dbo.Services", "ProductID");
            CreateIndex("dbo.Services", "ServiceProduct_ProductID");
            CreateIndex("dbo.ServiceProducts", "Service_ServiceID");
            AddForeignKey("dbo.Services", "ServiceProduct_ProductID", "dbo.ServiceProducts", "ProductID");
            AddForeignKey("dbo.Services", "ProductID", "dbo.ServiceProducts", "ProductID");
            AddForeignKey("dbo.ServiceProducts", "Service_ServiceID", "dbo.Services", "ServiceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceProducts", "Service_ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "ProductID", "dbo.ServiceProducts");
            DropForeignKey("dbo.Services", "ServiceProduct_ProductID", "dbo.ServiceProducts");
            DropIndex("dbo.ServiceProducts", new[] { "Service_ServiceID" });
            DropIndex("dbo.Services", new[] { "ServiceProduct_ProductID" });
            DropIndex("dbo.Services", new[] { "ProductID" });
            DropColumn("dbo.ServiceProducts", "Service_ServiceID");
            DropColumn("dbo.Services", "ServiceProduct_ProductID");
            DropColumn("dbo.Services", "ProductID");
            AddForeignKey("dbo.ServiceProducts", "ServiceID", "dbo.Services", "ServiceID");
        }
    }
}
