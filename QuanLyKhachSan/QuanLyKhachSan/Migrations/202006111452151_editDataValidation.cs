namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDataValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProducts", "ProductImage", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceProducts", "ProductName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProducts", "ProductName", c => c.String());
            DropColumn("dbo.ServiceProducts", "ProductImage");
        }
    }
}
