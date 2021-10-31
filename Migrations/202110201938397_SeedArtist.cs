namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedArtist : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[Artists] ([Id], [Name], [Address], [PhoneNumber], [HeaderText], [AboutText], [PortfolioText], [ServicesText], [TestimonialsText], [ContactText], [FacebookLink], [InstagramLink], [YoutubeLink], [TwitterLink], [WhatsappLink], [AboutImage_Id], [HeroImage_Id]) VALUES (1, N'Ebrahim Belal', N'Egypt - Rosetta', N'01020782164', N'Hi! This is Ebrahim Belal

                    ', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.

                    ', N'Lorem ipsum dolor sit amet, consectetur adipisicing elit

                    ', N'Expect nothing less than perfect.

                    ', N'This Is What My Clients Say About Me.

                    ', N'If you would like to find out more about how I can help you, please give me a call or send me an email.

                    ', N'https://www.facebook.com/ebrahim.belal.925', N'https://www.instagram.com/ebrahim.belalarts', N'https://www.youtube.com/BelalsArt', N'www.twitter.com', N'https://wa.me/2001020782164', NULL, NULL)
                ");
        }
        
        public override void Down()
        {
        }
    }
}
