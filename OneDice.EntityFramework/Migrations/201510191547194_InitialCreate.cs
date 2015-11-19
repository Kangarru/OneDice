namespace OneDice.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        EMail = c.String(maxLength: 50),
                        Password = c.String(),
                        ImageUrl = c.String(),
                        EmailVerified = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsDeactivated = c.Boolean(nullable: false),
                        GoogleID = c.String(),
                        FacebookID = c.String(),
                        TwitterID = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.EMail, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "EMail" });
            DropTable("dbo.Users");
        }
    }
}
