namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStatusEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("app.claims", "Status_Id", c => c.Guid());
            AddColumn("app.policies", "AuthorizedUser_UserName", c => c.String());
            CreateIndex("app.claims", "Status_Id");
            AddForeignKey("app.claims", "Status_Id", "dbo.StatusEntities", "Id");
            DropColumn("app.claims", "Status");
        }
        
        public override void Down()
        {
            AddColumn("app.claims", "Status", c => c.Int(nullable: false));
            DropForeignKey("app.claims", "Status_Id", "dbo.StatusEntities");
            DropIndex("app.claims", new[] { "Status_Id" });
            DropColumn("app.policies", "AuthorizedUser_UserName");
            DropColumn("app.claims", "Status_Id");
            DropTable("dbo.StatusEntities");
        }
    }
}
