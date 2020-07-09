namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageEmp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmpImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmpImage");
        }
    }
}
