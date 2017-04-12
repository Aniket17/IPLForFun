namespace IPLForFun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cleanup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "IsApproved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Teams", "IsApproved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Players", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "IsApproved");
            DropColumn("dbo.Teams", "IsApproved");
            DropColumn("dbo.Matches", "IsApproved");
        }
    }
}
