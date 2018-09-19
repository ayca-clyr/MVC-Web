namespace EF_Tekrar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilkDbOluşturma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Öğrenci",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ÖğrenciDers",
                c => new
                    {
                        Öğrenci_Id = c.Int(nullable: false),
                        Ders_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Öğrenci_Id, t.Ders_Id })
                .ForeignKey("dbo.Öğrenci", t => t.Öğrenci_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ders", t => t.Ders_Id, cascadeDelete: true)
                .Index(t => t.Öğrenci_Id)
                .Index(t => t.Ders_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ÖğrenciDers", "Ders_Id", "dbo.Ders");
            DropForeignKey("dbo.ÖğrenciDers", "Öğrenci_Id", "dbo.Öğrenci");
            DropIndex("dbo.ÖğrenciDers", new[] { "Ders_Id" });
            DropIndex("dbo.ÖğrenciDers", new[] { "Öğrenci_Id" });
            DropTable("dbo.ÖğrenciDers");
            DropTable("dbo.Öğrenci");
            DropTable("dbo.Ders");
        }
    }
}
