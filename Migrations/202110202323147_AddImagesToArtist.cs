namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagesToArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "HeroImagePath", c => c.String());
            AddColumn("dbo.Artists", "AboutImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "AboutImagePath");
            DropColumn("dbo.Artists", "HeroImagePath");
        }
    }
}
