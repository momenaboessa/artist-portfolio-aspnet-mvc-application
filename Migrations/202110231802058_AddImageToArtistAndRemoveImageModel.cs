namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToArtistAndRemoveImageModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "SectionId", "dbo.Sections");
            DropIndex("dbo.Images", new[] { "SectionId" });
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeroImagePath = c.String(),
                        AboutImagePath = c.String(),
                        SectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Images", "SectionId");
            AddForeignKey("dbo.Images", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
        }
    }
}
