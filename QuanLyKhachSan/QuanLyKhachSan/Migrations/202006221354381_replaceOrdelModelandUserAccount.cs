namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replaceOrdelModelandUserAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderModels", "UserID", c => c.Int());
            CreateIndex("dbo.OrderModels", "UserID");
            AddForeignKey("dbo.OrderModels", "UserID", "dbo.UserAccounts", "UserID");
            DropColumn("dbo.OrderModels", "OrderPerson");
            DropColumn("dbo.OrderModels", "OrderPhone");
            DropColumn("dbo.OrderModels", "OrderEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderModels", "OrderEmail", c => c.String());
            AddColumn("dbo.OrderModels", "OrderPhone", c => c.String());
            AddColumn("dbo.OrderModels", "OrderPerson", c => c.String());
            DropForeignKey("dbo.OrderModels", "UserID", "dbo.UserAccounts");
            DropIndex("dbo.OrderModels", new[] { "UserID" });
            DropColumn("dbo.OrderModels", "UserID");
        }
    }
}
