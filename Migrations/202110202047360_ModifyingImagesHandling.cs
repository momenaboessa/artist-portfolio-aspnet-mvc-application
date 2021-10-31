namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingImagesHandling : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artists", "AboutImage_Id", "dbo.Images");
            DropForeignKey("dbo.Artists", "HeroImage_Id", "dbo.Images");
            DropForeignKey("dbo.Projects", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Services", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Testimonials", "Image_Id", "dbo.Images");
            DropIndex("dbo.Artists", new[] { "AboutImage_Id" });
            DropIndex("dbo.Artists", new[] { "HeroImage_Id" });
            DropIndex("dbo.Projects", new[] { "ImageId" });
            DropIndex("dbo.Services", new[] { "ImageId" });
            DropIndex("dbo.Testimonials", new[] { "Image_Id" });
            AddColumn("dbo.Images", "SectionId", c => c.Byte(nullable: false));
            AddColumn("dbo.Projects", "ImagePath", c => c.String());
            AddColumn("dbo.Services", "ImagePath", c => c.String());
            AddColumn("dbo.Testimonials", "ImagePath", c => c.String());
            CreateIndex("dbo.Images", "SectionId");
            AddForeignKey("dbo.Images", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
            DropColumn("dbo.Artists", "AboutImage_Id");
            DropColumn("dbo.Artists", "HeroImage_Id");
            DropColumn("dbo.Images", "Title");
            DropColumn("dbo.Images", "Type");
            DropColumn("dbo.Projects", "ImageId");
            DropColumn("dbo.Services", "ImageId");
            DropColumn("dbo.Testimonials", "Image_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Testimonials", "Image_Id", c => c.Int());
            AddColumn("dbo.Services", "ImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "Title", c => c.String());
            AddColumn("dbo.Artists", "HeroImage_Id", c => c.Int());
            AddColumn("dbo.Artists", "AboutImage_Id", c => c.Int());
            DropForeignKey("dbo.Images", "SectionId", "dbo.Sections");
            DropIndex("dbo.Images", new[] { "SectionId" });
            DropColumn("dbo.Testimonials", "ImagePath");
            DropColumn("dbo.Services", "ImagePath");
            DropColumn("dbo.Projects", "ImagePath");
            DropColumn("dbo.Images", "SectionId");
            CreateIndex("dbo.Testimonials", "Image_Id");
            CreateIndex("dbo.Services", "ImageId");
            CreateIndex("dbo.Projects", "ImageId");
            CreateIndex("dbo.Artists", "HeroImage_Id");
            CreateIndex("dbo.Artists", "AboutImage_Id");
            AddForeignKey("dbo.Testimonials", "Image_Id", "dbo.Images", "Id");
            AddForeignKey("dbo.Services", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Artists", "HeroImage_Id", "dbo.Images", "Id");
            AddForeignKey("dbo.Artists", "AboutImage_Id", "dbo.Images", "Id");
        }
    }
}
