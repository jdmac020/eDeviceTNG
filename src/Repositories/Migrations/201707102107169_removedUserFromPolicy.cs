namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedUserFromPolicy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("app.policies", "AuthorizedUser_Id", "dbo.AspNetUsers");
            DropIndex("app.policies", new[] { "AuthorizedUser_Id" });
            AddColumn("app.policies", "AuthorizedUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("app.policies", "AuthorizedUser_Id", c => c.String());
            CreateIndex("app.policies", "AuthorizedUser_Id1");
            AddForeignKey("app.policies", "AuthorizedUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("app.policies", "AuthorizedUser_Id1", "dbo.AspNetUsers");
            DropIndex("app.policies", new[] { "AuthorizedUser_Id1" });
            AlterColumn("app.policies", "AuthorizedUser_Id", c => c.String(maxLength: 128));
            DropColumn("app.policies", "AuthorizedUser_Id1");
            CreateIndex("app.policies", "AuthorizedUser_Id");
            AddForeignKey("app.policies", "AuthorizedUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
