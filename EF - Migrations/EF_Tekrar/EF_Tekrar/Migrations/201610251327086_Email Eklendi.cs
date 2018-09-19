namespace EF_Tekrar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Öğrenci", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Öğrenci", "Email");
        }
    }
}
