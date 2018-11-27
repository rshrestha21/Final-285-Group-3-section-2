namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "servicetype_Id", "dbo.Servicetypes");
            DropIndex("dbo.Services", new[] { "servicetype_Id" });
            RenameColumn(table: "dbo.Services", name: "servicetype_Id", newName: "ServicetypeId");
            DropPrimaryKey("dbo.Servicetypes");
            AddColumn("dbo.Services", "ApplicationUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Servicetypes", "ServicetypeId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Services", "Name", c => c.String(maxLength: 10));
            AlterColumn("dbo.Services", "Desription", c => c.String(maxLength: 3000));
            AlterColumn("dbo.Services", "ServicetypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Servicetypes", "ServicetypeId");
            CreateIndex("dbo.Services", "ServicetypeId");
            CreateIndex("dbo.Services", "ApplicationUserID");
            AddForeignKey("dbo.Services", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Services", "ServicetypeId", "dbo.Servicetypes", "ServicetypeId", cascadeDelete: true);
            DropColumn("dbo.Servicetypes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicetypes", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Services", "ServicetypeId", "dbo.Servicetypes");
            DropForeignKey("dbo.Services", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Services", new[] { "ApplicationUserID" });
            DropIndex("dbo.Services", new[] { "ServicetypeId" });
            DropPrimaryKey("dbo.Servicetypes");
            AlterColumn("dbo.Services", "ServicetypeId", c => c.Int());
            AlterColumn("dbo.Services", "Desription", c => c.String());
            AlterColumn("dbo.Services", "Name", c => c.String());
            DropColumn("dbo.Servicetypes", "ServicetypeId");
            DropColumn("dbo.Services", "ApplicationUserID");
            AddPrimaryKey("dbo.Servicetypes", "Id");
            RenameColumn(table: "dbo.Services", name: "ServicetypeId", newName: "servicetype_Id");
            CreateIndex("dbo.Services", "servicetype_Id");
            AddForeignKey("dbo.Services", "servicetype_Id", "dbo.Servicetypes", "Id");
        }
    }
}
