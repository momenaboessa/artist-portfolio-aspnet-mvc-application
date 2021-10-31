namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Title", c => c.String());
            AddColumn("dbo.Images", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImagePath");
            DropColumn("dbo.Images", "Title");
        }
    }
}
