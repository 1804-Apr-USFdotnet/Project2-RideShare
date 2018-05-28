namespace RideAlongAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeadMemberColumnToSharesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shares", "LeadMember_Id", c => c.Int());
            CreateIndex("dbo.Shares", "LeadMember_Id");
            AddForeignKey("dbo.Shares", "LeadMember_Id", "dbo.Members", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shares", "LeadMember_Id", "dbo.Members");
            DropIndex("dbo.Shares", new[] { "LeadMember_Id" });
            DropColumn("dbo.Shares", "LeadMember_Id");
        }
    }
}
