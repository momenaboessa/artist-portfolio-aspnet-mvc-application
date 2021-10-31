namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCategories : DbMigration
    {
        public override void Up()
        {

            Sql(@"
                    INSERT INTO [dbo].[Categories] ([Name]) VALUES (N'Pharaonic')
                    INSERT INTO [dbo].[Categories] ([Name]) VALUES (N'Islamic')
                    INSERT INTO [dbo].[Categories] ([Name]) VALUES (N'Drawings')
                ");

        }
        
        public override void Down()
        {
        }
    }
}
