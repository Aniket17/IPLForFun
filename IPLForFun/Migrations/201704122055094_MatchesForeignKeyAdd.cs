namespace IPLForFun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatchesForeignKeyAdd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Matches", name: "Guest_TeamId", newName: "GuestTeamId");
            RenameColumn(table: "dbo.Matches", name: "Host_TeamId", newName: "HostTeamId");
            RenameIndex(table: "dbo.Matches", name: "IX_Host_TeamId", newName: "IX_HostTeamId");
            RenameIndex(table: "dbo.Matches", name: "IX_Guest_TeamId", newName: "IX_GuestTeamId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Matches", name: "IX_GuestTeamId", newName: "IX_Guest_TeamId");
            RenameIndex(table: "dbo.Matches", name: "IX_HostTeamId", newName: "IX_Host_TeamId");
            RenameColumn(table: "dbo.Matches", name: "HostTeamId", newName: "Host_TeamId");
            RenameColumn(table: "dbo.Matches", name: "GuestTeamId", newName: "Guest_TeamId");
        }
    }
}
