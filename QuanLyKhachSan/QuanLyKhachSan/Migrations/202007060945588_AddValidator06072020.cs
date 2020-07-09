namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidator06072020 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "FullName", c => c.String());
            AlterColumn("dbo.UserAccounts", "Phone", c => c.String(maxLength: 17));
            AlterColumn("dbo.UserAccounts", "CMND", c => c.String(maxLength: 17));
            AlterColumn("dbo.UserAccounts", "UserName", c => c.String());
            AlterColumn("dbo.UserAccounts", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "CMND", c => c.String(nullable: false, maxLength: 17));
            AlterColumn("dbo.UserAccounts", "Phone", c => c.String(nullable: false, maxLength: 17));
            AlterColumn("dbo.UserAccounts", "FullName", c => c.String(nullable: false));
        }
    }
}
