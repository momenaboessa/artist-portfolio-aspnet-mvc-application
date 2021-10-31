namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringsMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artists", "HeaderText", c => c.String(maxLength: 150));
            AlterColumn("dbo.Artists", "AboutText", c => c.String(maxLength: 600));
            AlterColumn("dbo.Artists", "PortfolioText", c => c.String(maxLength: 150));
            AlterColumn("dbo.Artists", "ServicesText", c => c.String(maxLength: 150));
            AlterColumn("dbo.Artists", "TestimonialsText", c => c.String(maxLength: 150));
            AlterColumn("dbo.Artists", "ContactText", c => c.String(maxLength: 150));
            AlterColumn("dbo.Projects", "Title", c => c.String(maxLength: 70));
            AlterColumn("dbo.Services", "Title", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Testimonials", "Name", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Testimonials", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Title", c => c.String());
            AlterColumn("dbo.Artists", "ContactText", c => c.String());
            AlterColumn("dbo.Artists", "TestimonialsText", c => c.String());
            AlterColumn("dbo.Artists", "ServicesText", c => c.String());
            AlterColumn("dbo.Artists", "PortfolioText", c => c.String());
            AlterColumn("dbo.Artists", "AboutText", c => c.String());
            AlterColumn("dbo.Artists", "HeaderText", c => c.String());
        }
    }
}
