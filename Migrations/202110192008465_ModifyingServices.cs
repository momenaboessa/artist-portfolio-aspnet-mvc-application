namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyingServices : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "Icon_Id", "dbo.Images");
            DropIndex("dbo.Services", new[] { "Icon_Id" });
            RenameColumn(table: "dbo.Services", name: "Icon_Id", newName: "ImageId");
            AlterColumn("dbo.Services", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Services", "ImageId");
            AddForeignKey("dbo.Services", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ImageId", "dbo.Images");
            DropIndex("dbo.Services", new[] { "ImageId" });
            AlterColumn("dbo.Services", "ImageId", c => c.Int());
            RenameColumn(table: "dbo.Services", name: "ImageId", newName: "Icon_Id");
            CreateIndex("dbo.Services", "Icon_Id");
            AddForeignKey("dbo.Services", "Icon_Id", "dbo.Images", "Id");
        }
    }
}
