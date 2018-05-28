namespace RideAlongAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyRelationshipForMembersAndShares : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carpools",
                c => new
                    {
                        ShareId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShareId, t.MemberId })
                .ForeignKey("dbo.Shares", t => t.ShareId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.ShareId)
                .Index(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carpools", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Carpools", "ShareId", "dbo.Shares");
            DropIndex("dbo.Carpools", new[] { "MemberId" });
            DropIndex("dbo.Carpools", new[] { "ShareId" });
            DropTable("dbo.Carpools");
        }
    }
}
