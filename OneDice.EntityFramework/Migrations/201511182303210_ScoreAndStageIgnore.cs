namespace OneDice.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScoreAndStageIgnore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "ScoreParams_ID", "dbo.Scores");
            DropForeignKey("dbo.Stages", "Game_ID", "dbo.Games");
            DropIndex("dbo.Games", new[] { "ScoreParams_ID" });
            DropIndex("dbo.Stages", new[] { "Game_ID" });
            DropColumn("dbo.Games", "ScoreParams_ID");
            DropColumn("dbo.Stages", "Game_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stages", "Game_ID", c => c.Int());
            AddColumn("dbo.Games", "ScoreParams_ID", c => c.Long());
            CreateIndex("dbo.Stages", "Game_ID");
            CreateIndex("dbo.Games", "ScoreParams_ID");
            AddForeignKey("dbo.Stages", "Game_ID", "dbo.Games", "ID");
            AddForeignKey("dbo.Games", "ScoreParams_ID", "dbo.Scores", "ID");
        }
    }
}
