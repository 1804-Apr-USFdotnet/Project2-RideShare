namespace RideAlongAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSharesFromUserTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shares", "ApplicationUser_Id", "dbo.User");
            DropIndex("dbo.Shares", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Shares", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shares", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Shares", "ApplicationUser_Id");
            AddForeignKey("dbo.Shares", "ApplicationUser_Id", "dbo.User", "Id");
        }
    }
}
