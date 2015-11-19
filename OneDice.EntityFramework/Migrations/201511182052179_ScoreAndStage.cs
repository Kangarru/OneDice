namespace OneDice.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScoreAndStage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GameType = c.String(),
                        NumberOfTeams = c.Int(nullable: false),
                        Description = c.String(),
                        UserId = c.String(),
                        LiveStreamUrl = c.String(),
                        BannerImages = c.String(),
                        Avatar = c.String(),
                        Name = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsDeactivated = c.Boolean(nullable: false),
                        ScoreParams_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Scores", t => t.ScoreParams_ID)
                .Index(t => t.ScoreParams_ID);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ScoringType = c.Int(nullable: false),
                        Ranged = c.Boolean(nullable: false),
                        Maximum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Minimum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CompetitionType = c.Int(nullable: false),
                        Ingress = c.Int(nullable: false),
                        Egress = c.Int(nullable: false),
                        Game_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Games", t => t.Game_ID)
                .Index(t => t.Game_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stages", "Game_ID", "dbo.Games");
            DropForeignKey("dbo.Games", "ScoreParams_ID", "dbo.Scores");
            DropIndex("dbo.Stages", new[] { "Game_ID" });
            DropIndex("dbo.Games", new[] { "ScoreParams_ID" });
            DropTable("dbo.Stages");
            DropTable("dbo.Scores");
            DropTable("dbo.Games");
        }
    }
}
