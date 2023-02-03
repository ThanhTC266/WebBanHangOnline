namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateActive1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_News", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_News", "IsActive");
        }
    }
}
