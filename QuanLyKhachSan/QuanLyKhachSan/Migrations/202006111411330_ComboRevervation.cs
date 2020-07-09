namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComboRevervation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Revervations",
                c => new
                    {
                        ReverID = c.Int(nullable: false, identity: true),
                        InDateTime = c.DateTime(),
                        OutDateTime = c.DateTime(),
                        UserID = c.Int(),
                        RoomId = c.Int(),
                        Paying = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReverID)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .ForeignKey("dbo.UserAccounts", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        ReverID = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.Revervations", t => t.ReverID)
                .Index(t => t.ReverID);
            
            CreateTable(
                "dbo.ServiceProducts",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.Int(nullable: false),
                        ServiceID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Services", t => t.ServiceID)
                .Index(t => t.ServiceID);
            
            AddColumn("dbo.UserAccounts", "CMND", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceProducts", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "ReverID", "dbo.Revervations");
            DropForeignKey("dbo.Revervations", "UserID", "dbo.UserAccounts");
            DropForeignKey("dbo.Revervations", "RoomId", "dbo.Rooms");
            DropIndex("dbo.ServiceProducts", new[] { "ServiceID" });
            DropIndex("dbo.Services", new[] { "ReverID" });
            DropIndex("dbo.Revervations", new[] { "RoomId" });
            DropIndex("dbo.Revervations", new[] { "UserID" });
            DropColumn("dbo.UserAccounts", "CMND");
            DropTable("dbo.ServiceProducts");
            DropTable("dbo.Services");
            DropTable("dbo.Revervations");
        }
    }
}
