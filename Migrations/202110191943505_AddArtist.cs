namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArtist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        HeaderText = c.String(),
                        AboutText = c.String(),
                        PortfolioText = c.String(),
                        ServicesText = c.String(),
                        TestimonialsText = c.String(),
                        ContactText = c.String(),
                        FacebookLink = c.String(),
                        InstagramLink = c.String(),
                        YoutubeLink = c.String(),
                        TwitterLink = c.String(),
                        WhatsappLink = c.String(),
                        AboutImage_Id = c.Int(),
                        HeroImage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.AboutImage_Id)
                .ForeignKey("dbo.Images", t => t.HeroImage_Id)
                .Index(t => t.AboutImage_Id)
                .Index(t => t.HeroImage_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artists", "HeroImage_Id", "dbo.Images");
            DropForeignKey("dbo.Artists", "AboutImage_Id", "dbo.Images");
            DropIndex("dbo.Artists", new[] { "HeroImage_Id" });
            DropIndex("dbo.Artists", new[] { "AboutImage_Id" });
            DropTable("dbo.Images");
            DropTable("dbo.Artists");
        }
    }
}
