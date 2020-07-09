namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditSerAndRever : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Revervations", "ServiceID", "dbo.Services");
            AddColumn("dbo.Revervations", "Service_ServiceID", c => c.Int());
            AddColumn("dbo.Services", "ReverID", c => c.Int());
            CreateIndex("dbo.Revervations", "Service_ServiceID");
            CreateIndex("dbo.Services", "ReverID");
            AddForeignKey("dbo.Services", "ReverID", "dbo.Revervations", "ReverID");
            AddForeignKey("dbo.Revervations", "Service_ServiceID", "dbo.Services", "ServiceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Revervations", "Service_ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "ReverID", "dbo.Revervations");
            DropIndex("dbo.Services", new[] { "ReverID" });
            DropIndex("dbo.Revervations", new[] { "Service_ServiceID" });
            DropColumn("dbo.Services", "ReverID");
            DropColumn("dbo.Revervations", "Service_ServiceID");
            AddForeignKey("dbo.Revervations", "ServiceID", "dbo.Services", "ServiceID");
        }
    }
}
