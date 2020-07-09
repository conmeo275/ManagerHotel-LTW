namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEmp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        RoleDes = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Employees", "RoleID", c => c.Int());
            CreateIndex("dbo.Employees", "RoleID");
            AddForeignKey("dbo.Employees", "RoleID", "dbo.Roles", "RoleID");
            DropColumn("dbo.Employees", "EmpRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmpRole", c => c.String());
            DropForeignKey("dbo.Employees", "RoleID", "dbo.Roles");
            DropIndex("dbo.Employees", new[] { "RoleID" });
            DropColumn("dbo.Employees", "RoleID");
            DropTable("dbo.Roles");
        }
    }
}
