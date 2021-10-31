namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIAmsAndSections : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.IAms");
            DropTable("dbo.Sections");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IAms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
