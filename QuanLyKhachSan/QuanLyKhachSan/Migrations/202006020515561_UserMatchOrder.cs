namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMatchOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderModels", "UserID", c => c.Int());
            AddColumn("dbo.UserAccounts", "Phone", c => c.String(nullable: false));
            CreateIndex("dbo.OrderModels", "UserID");
            AddForeignKey("dbo.OrderModels", "UserID", "dbo.UserAccounts", "UserID");
            DropColumn("dbo.OrderModels", "OrderName");
            DropColumn("dbo.OrderModels", "OrderEmail");
            DropColumn("dbo.OrderModels", "OrderPhone");
            DropColumn("dbo.UserAccounts", "UserImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "UserImage", c => c.String(nullable: false));
            AddColumn("dbo.OrderModels", "OrderPhone", c => c.String(nullable: false));
            AddColumn("dbo.OrderModels", "OrderEmail", c => c.String(nullable: false));
            AddColumn("dbo.OrderModels", "OrderName", c => c.String(nullable: false));
            DropForeignKey("dbo.OrderModels", "UserID", "dbo.UserAccounts");
            DropIndex("dbo.OrderModels", new[] { "UserID" });
            DropColumn("dbo.UserAccounts", "Phone");
            DropColumn("dbo.OrderModels", "UserID");
        }
    }
}
