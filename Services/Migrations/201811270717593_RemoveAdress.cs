namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAdress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Address", c => c.String());
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Address", c => c.String(nullable: false));
        }
    }
}
