namespace IPLForFun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedApprovedFromPlayer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "IsApproved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "IsApproved", c => c.Boolean(nullable: false));
        }
    }
}
