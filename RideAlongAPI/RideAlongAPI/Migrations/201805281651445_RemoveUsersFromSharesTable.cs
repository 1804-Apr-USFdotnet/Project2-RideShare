namespace RideAlongAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUsersFromSharesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "Share_Id", "dbo.Shares");
            DropIndex("dbo.User", new[] { "Share_Id" });
            DropColumn("dbo.User", "Share_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Share_Id", c => c.Int());
            CreateIndex("dbo.User", "Share_Id");
            AddForeignKey("dbo.User", "Share_Id", "dbo.Shares", "Id");
        }
    }
}
