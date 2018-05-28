namespace RideAlongAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembersTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Members");
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
