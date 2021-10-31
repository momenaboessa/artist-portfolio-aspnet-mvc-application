namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalCategories1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                DELETE FROM [dbo].[Categories]
                SET IDENTITY_INSERT [dbo].[Categories] ON
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Ancient Egyptian')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Islamic')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Different Cultures')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Tourist Attraction')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Other Sculptures')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Drawings')");
        }
        
        public override void Down()
        {
        }
    }
}
