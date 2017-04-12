namespace IPLForFun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyTeamtoPlayer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Players", name: "Team_TeamId", newName: "TeamId");
            RenameIndex(table: "dbo.Players", name: "IX_Team_TeamId", newName: "IX_TeamId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Players", name: "IX_TeamId", newName: "IX_Team_TeamId");
            RenameColumn(table: "dbo.Players", name: "TeamId", newName: "Team_TeamId");
        }
    }
}
