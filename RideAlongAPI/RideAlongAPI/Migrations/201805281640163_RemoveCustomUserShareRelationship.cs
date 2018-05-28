namespace RideAlongAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomUserShareRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RideShares", "ShareId", "dbo.Shares");
            DropForeignKey("dbo.RideShares", "UserId", "dbo.User");
            DropIndex("dbo.RideShares", new[] { "ShareId" });
            DropIndex("dbo.RideShares", new[] { "UserId" });
            AddColumn("dbo.Shares", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.User", "Share_Id", c => c.Int());
            CreateIndex("dbo.Shares", "ApplicationUser_Id");
            CreateIndex("dbo.User", "Share_Id");
            AddForeignKey("dbo.Shares", "ApplicationUser_Id", "dbo.User", "Id");
            AddForeignKey("dbo.User", "Share_Id", "dbo.Shares", "Id");
            DropTable("dbo.RideShares");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RideShares",
                c => new
                    {
                        ShareId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ShareId, t.UserId });
            
            DropForeignKey("dbo.User", "Share_Id", "dbo.Shares");
            DropForeignKey("dbo.Shares", "ApplicationUser_Id", "dbo.User");
            DropIndex("dbo.User", new[] { "Share_Id" });
            DropIndex("dbo.Shares", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.User", "Share_Id");
            DropColumn("dbo.Shares", "ApplicationUser_Id");
            CreateIndex("dbo.RideShares", "UserId");
            CreateIndex("dbo.RideShares", "ShareId");
            AddForeignKey("dbo.RideShares", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RideShares", "ShareId", "dbo.Shares", "Id", cascadeDelete: true);
        }
    }
}
