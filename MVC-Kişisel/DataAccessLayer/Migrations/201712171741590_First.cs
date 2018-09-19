namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        ImageId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Images", t => t.ImageId)
                .ForeignKey("dbo.People", t => t.PeopleId)
                .Index(t => t.PeopleId)
                .Index(t => t.ImageId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ImgUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 100),
                        Age = c.DateTime(nullable: false, storeType: "date"),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Address = c.String(),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Branch = c.String(nullable: false, maxLength: 200),
                        DateOfStart = c.String(maxLength: 100),
                        DateOfEnd = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PeopleId)
                .Index(t => t.PeopleId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Grade = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PeopleId)
                .Index(t => t.PeopleId);
            
            CreateTable(
                "dbo.Socials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleId = c.Int(nullable: false),
                        Facebook = c.String(maxLength: 200),
                        Linkedin = c.String(maxLength: 200),
                        Instagram = c.String(maxLength: 200),
                        GitHub = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PeopleId)
                .Index(t => t.PeopleId);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Branch = c.String(nullable: false, maxLength: 200),
                        DateOfStart = c.String(maxLength: 100),
                        DateOfEnd = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PeopleId)
                .Index(t => t.PeopleId);
            
            CreateTable(
                "dbo.Project_Technology",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        TechnologyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Technologies", t => t.TechnologyId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.TechnologyId);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project_Technology", "TechnologyId", "dbo.Technologies");
            DropForeignKey("dbo.Project_Technology", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "PeopleId", "dbo.People");
            DropForeignKey("dbo.Works", "PeopleId", "dbo.People");
            DropForeignKey("dbo.Socials", "PeopleId", "dbo.People");
            DropForeignKey("dbo.Skills", "PeopleId", "dbo.People");
            DropForeignKey("dbo.Educations", "PeopleId", "dbo.People");
            DropForeignKey("dbo.Projects", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Project_Technology", new[] { "TechnologyId" });
            DropIndex("dbo.Project_Technology", new[] { "ProjectId" });
            DropIndex("dbo.Works", new[] { "PeopleId" });
            DropIndex("dbo.Socials", new[] { "PeopleId" });
            DropIndex("dbo.Skills", new[] { "PeopleId" });
            DropIndex("dbo.Educations", new[] { "PeopleId" });
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropIndex("dbo.Projects", new[] { "ImageId" });
            DropIndex("dbo.Projects", new[] { "PeopleId" });
            DropTable("dbo.Users");
            DropTable("dbo.Technologies");
            DropTable("dbo.Project_Technology");
            DropTable("dbo.Works");
            DropTable("dbo.Socials");
            DropTable("dbo.Skills");
            DropTable("dbo.Educations");
            DropTable("dbo.People");
            DropTable("dbo.Images");
            DropTable("dbo.Projects");
            DropTable("dbo.Categories");
        }
    }
}
