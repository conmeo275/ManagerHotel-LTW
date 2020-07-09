namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentAndBill01072020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        ReverID = c.Int(),
                        PayID = c.Int(),
                        Emp = c.String(),
                        CurrentTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.BillID)
                .ForeignKey("dbo.Payments", t => t.PayID)
                .ForeignKey("dbo.Revervations", t => t.ReverID)
                .Index(t => t.ReverID)
                .Index(t => t.PayID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PayID = c.Int(nullable: false, identity: true),
                        ReverID = c.Int(),
                        RoomFee = c.Int(nullable: false),
                        ServiceFee = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PayID)
                .ForeignKey("dbo.Revervations", t => t.ReverID)
                .Index(t => t.ReverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "ReverID", "dbo.Revervations");
            DropForeignKey("dbo.Bills", "PayID", "dbo.Payments");
            DropForeignKey("dbo.Payments", "ReverID", "dbo.Revervations");
            DropIndex("dbo.Payments", new[] { "ReverID" });
            DropIndex("dbo.Bills", new[] { "PayID" });
            DropIndex("dbo.Bills", new[] { "ReverID" });
            DropTable("dbo.Payments");
            DropTable("dbo.Bills");
        }
    }
}
