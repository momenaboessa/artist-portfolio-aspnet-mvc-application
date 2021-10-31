namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedSections : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (1 ,N'hero')
                    INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (2 ,N'about')
                    INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (3 ,N'portfolio')
                    INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (4 ,N'testimonials')
                    INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (5 ,N'services')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
