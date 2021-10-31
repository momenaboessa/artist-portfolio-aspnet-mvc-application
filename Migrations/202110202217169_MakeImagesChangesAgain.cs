namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeImagesChangesAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "HeroImagePath", c => c.String());
            AddColumn("dbo.Images", "AboutImagePath", c => c.String());
            DropColumn("dbo.Images", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImagePath", c => c.String());
            DropColumn("dbo.Images", "AboutImagePath");
            DropColumn("dbo.Images", "HeroImagePath");
        }
    }
}
