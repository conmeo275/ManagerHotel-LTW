namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        EmpName = c.String(nullable: false),
                        EmpDayOfBirth = c.DateTime(),
                        EmpEmail = c.String(),
                        EmpRole = c.String(),
                        EmpAddress = c.String(nullable: false),
                        EmpPhone = c.String(nullable: false),
                        EmpUserName = c.String(nullable: false),
                        EmpPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmpID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        TypeID = c.Int(),
                        StatusID = c.Int(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.RoomTypes", t => t.TypeID)
                .ForeignKey("dbo.StatusRooms", t => t.StatusID)
                .Index(t => t.TypeID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        TypeImage = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.StatusRooms",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                        StatusColor = c.String(),
                    })
                .PrimaryKey(t => t.StatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "StatusID", "dbo.StatusRooms");
            DropForeignKey("dbo.Rooms", "TypeID", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "StatusID" });
            DropIndex("dbo.Rooms", new[] { "TypeID" });
            DropTable("dbo.StatusRooms");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Employees");
        }
    }
}
