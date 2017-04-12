namespace IPLForFun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Views : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Guest_TeamId = c.Int(nullable: false),
                        Host_TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Teams", t => t.Guest_TeamId, cascadeDelete: false)
                .ForeignKey("dbo.Teams", t => t.Host_TeamId, cascadeDelete: false)
                .Index(t => t.Guest_TeamId)
                .Index(t => t.Host_TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Team_TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId, cascadeDelete: true)
                .Index(t => t.Team_TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Host_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Guest_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "Team_TeamId", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "Team_TeamId" });
            DropIndex("dbo.Matches", new[] { "Host_TeamId" });
            DropIndex("dbo.Matches", new[] { "Guest_TeamId" });
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
        }
    }
}
