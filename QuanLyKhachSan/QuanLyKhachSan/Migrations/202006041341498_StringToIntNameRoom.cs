namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringToIntNameRoom : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "RoomName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "RoomName", c => c.String());
        }
    }
}
