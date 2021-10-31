namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TurnIdsToIntegers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IAms", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Images", "SectionId", "dbo.Sections");
            DropIndex("dbo.IAms", new[] { "ArtistId" });
            DropIndex("dbo.Images", new[] { "SectionId" });
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Artists");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Sections");
            DropPrimaryKey("dbo.Services");
            DropPrimaryKey("dbo.Testimonials");
            AlterColumn("dbo.Artists", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Images", "SectionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sections", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Projects", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Services", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Testimonials", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Artists", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Sections", "Id");
            AddPrimaryKey("dbo.Services", "Id");
            AddPrimaryKey("dbo.Testimonials", "Id");
            CreateIndex("dbo.Images", "SectionId");
            CreateIndex("dbo.Projects", "CategoryId");
            AddForeignKey("dbo.Projects", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Images", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
            DropColumn("dbo.IAms", "ArtistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IAms", "ArtistId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Images", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropIndex("dbo.Images", new[] { "SectionId" });
            DropPrimaryKey("dbo.Testimonials");
            DropPrimaryKey("dbo.Services");
            DropPrimaryKey("dbo.Sections");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Artists");
            AlterColumn("dbo.Testimonials", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Services", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Projects", "CategoryId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Sections", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Images", "SectionId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Artists", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Testimonials", "Id");
            AddPrimaryKey("dbo.Services", "Id");
            AddPrimaryKey("dbo.Sections", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Artists", "Id");
            CreateIndex("dbo.Projects", "CategoryId");
            CreateIndex("dbo.Images", "SectionId");
            CreateIndex("dbo.IAms", "ArtistId");
            AddForeignKey("dbo.Images", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IAms", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
        }
    }
}
