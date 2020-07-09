namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderModels", "OrderName", c => c.String(nullable: false));
            AlterColumn("dbo.OrderModels", "OrderEmail", c => c.String(nullable: false));
            AlterColumn("dbo.OrderModels", "OrderPhone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderModels", "OrderPhone", c => c.String());
            AlterColumn("dbo.OrderModels", "OrderEmail", c => c.String());
            AlterColumn("dbo.OrderModels", "OrderName", c => c.String());
        }
    }
}
