namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "app.statuses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("app.claims", "StatusId", c => c.Guid(nullable: false));
            AddColumn("app.claims", "StatusName", c => c.String());
            CreateIndex("app.claims", "StatusId");
            AddForeignKey("app.claims", "StatusId", "app.statuses", "Id", cascadeDelete: true);
            DropColumn("app.claims", "Status");
        }
        
        public override void Down()
        {
            AddColumn("app.claims", "Status", c => c.Int(nullable: false));
            DropForeignKey("app.claims", "StatusId", "app.statuses");
            DropIndex("app.claims", new[] { "StatusId" });
            DropColumn("app.claims", "StatusName");
            DropColumn("app.claims", "StatusId");
            DropTable("app.statuses");
        }
    }
}
