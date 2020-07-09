namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusPropati06072020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderModels", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderModels", "Status");
        }
    }
}
