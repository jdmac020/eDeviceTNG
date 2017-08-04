namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedStatusSchema : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StatusEntities", newName: "statuses");
            MoveTable(name: "dbo.statuses", newSchema: "app");
        }
        
        public override void Down()
        {
            MoveTable(name: "app.statuses", newSchema: "dbo");
            RenameTable(name: "dbo.statuses", newName: "StatusEntities");
        }
    }
}
