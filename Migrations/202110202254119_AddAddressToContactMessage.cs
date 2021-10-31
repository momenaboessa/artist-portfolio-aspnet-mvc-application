namespace Artist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToContactMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactMessages", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactMessages", "Address");
        }
    }
}
