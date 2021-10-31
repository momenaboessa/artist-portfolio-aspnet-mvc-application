namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCategories1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Pharaonic')
                    INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Islamic')
                    INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Drawings')
               ");
        }
        
        public override void Down()
        {
        }
    }
}
