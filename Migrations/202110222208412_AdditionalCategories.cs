namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalCategories : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                DELETE FROM [dbo].[Categories]
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Pharaonic')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Islamic')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Different cultures')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Tourist attraction')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Other sculptures')
                INSERT INTO [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Drawings')");
        }
        
        public override void Down()
        {
        }
    }
}
