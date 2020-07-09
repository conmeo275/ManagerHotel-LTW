namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderModels", "OrderDateTime", c => c.DateTime());
            AlterColumn("dbo.OrderModels", "OrderPhone", c => c.String());
            AlterColumn("dbo.UserAccounts", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.OrderModels", "OrderPhone", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderModels", "OrderDateTime", c => c.DateTime(nullable: false));
        }
    }
}
