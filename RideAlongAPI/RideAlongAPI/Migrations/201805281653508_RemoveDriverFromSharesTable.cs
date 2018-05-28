namespace RideAlongAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDriverFromSharesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shares", "FK_dbo.Shares_dbo.AspNetUsers_Driver_Id");
            DropForeignKey("dbo.Shares", "Driver_Id", "dbo.User");
            DropIndex("dbo.Shares", new[] { "Driver_Id" });
            DropColumn("dbo.Shares", "Driver_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shares", "Driver_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Shares", "Driver_Id");
            AddForeignKey("dbo.Shares", "Driver_Id", "dbo.User", "Id");
        }
    }
}
