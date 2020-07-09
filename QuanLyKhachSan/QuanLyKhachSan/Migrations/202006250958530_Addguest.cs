namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addguest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Revervations", "GuestID", "dbo.Guests");
            DropIndex("dbo.Revervations", new[] { "GuestID" });
            AddColumn("dbo.Revervations", "GuestName", c => c.String(nullable: false));
            AddColumn("dbo.Revervations", "GuestEmail", c => c.String());
            AddColumn("dbo.Revervations", "GuestPhone", c => c.String(nullable: false, maxLength: 17));
            AddColumn("dbo.Revervations", "GuestCMND", c => c.String(nullable: false, maxLength: 17));
            DropColumn("dbo.Revervations", "GuestID");
            DropTable("dbo.Guests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        GuestID = c.Int(nullable: false, identity: true),
                        GuestName = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(nullable: false, maxLength: 17),
                        CMND = c.String(nullable: false, maxLength: 17),
                    })
                .PrimaryKey(t => t.GuestID);
            
            AddColumn("dbo.Revervations", "GuestID", c => c.Int());
            DropColumn("dbo.Revervations", "GuestCMND");
            DropColumn("dbo.Revervations", "GuestPhone");
            DropColumn("dbo.Revervations", "GuestEmail");
            DropColumn("dbo.Revervations", "GuestName");
            CreateIndex("dbo.Revervations", "GuestID");
            AddForeignKey("dbo.Revervations", "GuestID", "dbo.Guests", "GuestID");
        }
    }
}
