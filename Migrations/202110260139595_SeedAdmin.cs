namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a34b7a2-e1e3-4ec1-8882-da7a88a41ede', N'admin@admin.com', 0, N'ACp6LgwAvHlUIitu3vCwEkCKthxXLTBs4uycybtXxt0d8xmBuusAFDMFQGx3MuRRHQ==', N'4e5dc47f-8a0b-4a9d-be04-f5a4c8c60f43', NULL, 0, 0, NULL, 1, 0, N'ebrahim@belal.com')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
