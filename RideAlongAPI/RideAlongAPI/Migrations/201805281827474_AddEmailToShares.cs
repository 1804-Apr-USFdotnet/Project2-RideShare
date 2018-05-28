namespace RideAlongAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailToShares : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shares", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shares", "Email");
        }
    }
}
