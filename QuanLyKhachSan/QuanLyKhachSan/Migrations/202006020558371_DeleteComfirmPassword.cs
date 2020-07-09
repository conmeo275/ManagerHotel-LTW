namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteComfirmPassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAccounts", "ComfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "ComfirmPassword", c => c.String());
        }
    }
}
