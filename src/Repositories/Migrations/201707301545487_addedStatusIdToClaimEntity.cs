namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStatusIdToClaimEntity : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("app.claims", "Status_Id", "dbo.StatusEntities");
            //DropIndex("app.claims", new[] { "Status_Id" });
            RenameColumn(table: "app.claims", name: "Status_Id", newName: "StatusId");
            AlterColumn("app.claims", "StatusId", c => c.Guid(nullable: false));
            //CreateIndex("app.claims", "StatusId");
            //AddForeignKey("app.claims", "StatusId", "dbo.StatusEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("app.claims", "StatusId", "dbo.StatusEntities");
            //DropIndex("app.claims", new[] { "StatusId" });
            AlterColumn("app.claims", "StatusId", c => c.Guid());
            RenameColumn(table: "app.claims", name: "StatusId", newName: "Status_Id");
            //CreateIndex("app.claims", "Status_Id");
            //AddForeignKey("app.claims", "Status_Id", "dbo.StatusEntities", "Id");
        }
    }
}
