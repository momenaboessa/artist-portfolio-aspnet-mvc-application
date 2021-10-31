namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestimonials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        FeedBack = c.String(),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Image_Id)
                .Index(t => t.Image_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Testimonials", "Image_Id", "dbo.Images");
            DropIndex("dbo.Testimonials", new[] { "Image_Id" });
            DropTable("dbo.Testimonials");
        }
    }
}
