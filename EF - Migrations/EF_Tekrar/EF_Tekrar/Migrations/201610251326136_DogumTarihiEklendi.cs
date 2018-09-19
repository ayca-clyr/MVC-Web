namespace EF_Tekrar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DogumTarihiEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Öğrenci", "DogumTarihi", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Öğrenci", "DogumTarihi");
        }
    }
}
