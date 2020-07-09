namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBill01072020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "ReverID", "dbo.Revervations");
            DropIndex("dbo.Bills", new[] { "ReverID" });
            DropColumn("dbo.Bills", "ReverID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "ReverID", c => c.Int());
            CreateIndex("dbo.Bills", "ReverID");
            AddForeignKey("dbo.Bills", "ReverID", "dbo.Revervations", "ReverID");
        }
    }
}
