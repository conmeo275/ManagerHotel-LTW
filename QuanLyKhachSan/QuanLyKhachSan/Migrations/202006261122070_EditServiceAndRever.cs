namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditServiceAndRever : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Revervations", "ServiceID", c => c.Int());
            CreateIndex("dbo.Revervations", "ServiceID");
            AddForeignKey("dbo.Revervations", "ServiceID", "dbo.Services", "ServiceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Revervations", "ServiceID", "dbo.Services");
            DropIndex("dbo.Revervations", new[] { "ServiceID" });
            DropColumn("dbo.Revervations", "ServiceID");
        }
    }
}
