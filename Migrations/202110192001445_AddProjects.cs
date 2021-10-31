namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CategoryId = c.Byte(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "ImageId" });
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropTable("dbo.Projects");
        }
    }
}
