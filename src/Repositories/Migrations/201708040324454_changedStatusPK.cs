namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedStatusPK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("app.claims", "StatusId", "dbo.StatusEntities");
            DropIndex("app.claims", new[] { "StatusId" });
            DropPrimaryKey("dbo.StatusEntities");
            //AddColumn("app.claims", "Status_Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.StatusEntities", "Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.StatusEntities", "Name");
            //CreateIndex("app.claims", "Status_Name");
            //AddForeignKey("app.claims", "Status_Name", "dbo.StatusEntities", "Name");
        }
        
        public override void Down()
        {
            //DropForeignKey("app.claims", "Status_Name", "dbo.StatusEntities");
            //DropIndex("app.claims", new[] { "Status_Name" });
            DropPrimaryKey("dbo.StatusEntities");
            AlterColumn("dbo.StatusEntities", "Name", c => c.String());
            //DropColumn("app.claims", "Status_Name");
            AddPrimaryKey("dbo.StatusEntities", "Id");
            //CreateIndex("app.claims", "StatusId");
            //AddForeignKey("app.claims", "StatusId", "dbo.StatusEntities", "Id", cascadeDelete: true);
        }
    }
}
