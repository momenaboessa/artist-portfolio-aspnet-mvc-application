namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkingPeriodToArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "WorkingPeriod", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "WorkingPeriod");
        }
    }
}
