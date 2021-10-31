namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRequiredProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Testimonials", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Testimonials", "FeedBack", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Testimonials", "FeedBack", c => c.String());
            AlterColumn("dbo.Testimonials", "Name", c => c.String());
            AlterColumn("dbo.Services", "Description", c => c.String());
            AlterColumn("dbo.Services", "Title", c => c.String());
        }
    }
}
