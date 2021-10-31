namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Icon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Icon_Id)
                .Index(t => t.Icon_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "Icon_Id", "dbo.Images");
            DropIndex("dbo.Services", new[] { "Icon_Id" });
            DropTable("dbo.Services");
        }
    }
}
