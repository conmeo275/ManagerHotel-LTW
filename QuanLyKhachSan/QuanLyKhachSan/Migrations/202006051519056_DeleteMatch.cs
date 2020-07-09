namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMatch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderModels", "UserID", "dbo.UserAccounts");
            DropIndex("dbo.OrderModels", new[] { "UserID" });
            AddColumn("dbo.OrderModels", "OrderPerson", c => c.String());
            AddColumn("dbo.OrderModels", "OrderPhone", c => c.String());
            AddColumn("dbo.OrderModels", "OrderEmail", c => c.String());
            AddColumn("dbo.OrderModels", "OrderRoom", c => c.String());
            DropColumn("dbo.OrderModels", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderModels", "UserID", c => c.Int());
            DropColumn("dbo.OrderModels", "OrderRoom");
            DropColumn("dbo.OrderModels", "OrderEmail");
            DropColumn("dbo.OrderModels", "OrderPhone");
            DropColumn("dbo.OrderModels", "OrderPerson");
            CreateIndex("dbo.OrderModels", "UserID");
            AddForeignKey("dbo.OrderModels", "UserID", "dbo.UserAccounts", "UserID");
        }
    }
}
