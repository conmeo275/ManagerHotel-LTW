namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderModel07072020 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderModels", "CheckIn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderModels", "CheckOut", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderModels", "CheckOut", c => c.DateTime());
            AlterColumn("dbo.OrderModels", "CheckIn", c => c.DateTime());
        }
    }
}
