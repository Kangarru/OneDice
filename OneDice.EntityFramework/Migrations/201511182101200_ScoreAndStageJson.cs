namespace OneDice.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScoreAndStageJson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "StageListJson", c => c.String());
            AddColumn("dbo.Games", "ScoreJson", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "ScoreJson");
            DropColumn("dbo.Games", "StageListJson");
        }
    }
}
