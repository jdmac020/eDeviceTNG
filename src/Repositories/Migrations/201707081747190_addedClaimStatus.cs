namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedClaimStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("app.claims", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("app.claims", "Status");
        }
    }
}
