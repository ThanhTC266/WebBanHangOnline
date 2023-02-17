namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStudent2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Students", newName: "tb_Students");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_Students", newName: "Students");
        }
    }
}
