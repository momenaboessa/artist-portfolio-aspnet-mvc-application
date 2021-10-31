namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIAms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IAms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ArtistId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IAms", "ArtistId", "dbo.Artists");
            DropIndex("dbo.IAms", new[] { "ArtistId" });
            DropTable("dbo.IAms");
        }
    }
}
