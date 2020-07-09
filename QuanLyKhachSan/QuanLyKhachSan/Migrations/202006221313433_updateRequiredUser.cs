namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRequiredUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "Phone", c => c.String(nullable: false, maxLength: 17));
            AlterColumn("dbo.UserAccounts", "CMND", c => c.String(nullable: false, maxLength: 17));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "CMND", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "Phone", c => c.String(nullable: false));
        }
    }
}
