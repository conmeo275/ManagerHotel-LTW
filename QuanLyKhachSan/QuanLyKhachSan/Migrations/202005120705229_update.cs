namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderModels", "OrderDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderModels", "OrderDateTime", c => c.DateTime(nullable: false));
        }
    }
}
