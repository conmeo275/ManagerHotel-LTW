namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGuestModel : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Revervations", "GuestID");
            AddForeignKey("dbo.Revervations", "GuestID", "dbo.Guests", "GuestID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Revervations", "GuestID", "dbo.Guests");
            DropIndex("dbo.Revervations", new[] { "GuestID" });
            DropColumn("dbo.Revervations", "GuestID");
            DropTable("dbo.Guests");
        }
    }
}
