namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditKey29062020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Revervations", "ServiceID", "dbo.Services");
            DropIndex("dbo.Revervations", new[] { "ServiceID" });
            AddColumn("dbo.Services", "ReverID", c => c.Int());
            CreateIndex("dbo.Services", "ReverID");
            AddForeignKey("dbo.Services", "ReverID", "dbo.Revervations", "ReverID");
            DropColumn("dbo.Revervations", "ServiceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Revervations", "ServiceID", c => c.Int());
            DropForeignKey("dbo.Services", "ReverID", "dbo.Revervations");
            DropIndex("dbo.Services", new[] { "ReverID" });
            DropColumn("dbo.Services", "ReverID");
            CreateIndex("dbo.Revervations", "ServiceID");
            AddForeignKey("dbo.Revervations", "ServiceID", "dbo.Services", "ServiceID");
        }
    }
}
