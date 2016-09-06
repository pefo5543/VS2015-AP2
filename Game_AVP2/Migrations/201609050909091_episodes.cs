namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class episodes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameEpisodes",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        EpisodeId = c.Byte(nullable: false),
                        StartScore = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.EpisodeId })
                .ForeignKey("dbo.Episodes", t => t.EpisodeId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId)
                .Index(t => t.GameId)
                .Index(t => t.EpisodeId);
            
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        EpisodeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.EpisodeId);
            
            AddColumn("dbo.Stories", "IsFirst", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stories", "IsLast", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stories", "IsDialogue", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stories", "Episode_EpisodeId", c => c.Byte());
            CreateIndex("dbo.Stories", "Episode_EpisodeId");
            AddForeignKey("dbo.Stories", "Episode_EpisodeId", "dbo.Episodes", "EpisodeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameEpisodes", "GameId", "dbo.Games");
            DropForeignKey("dbo.GameEpisodes", "EpisodeId", "dbo.Episodes");
            DropForeignKey("dbo.Stories", "Episode_EpisodeId", "dbo.Episodes");
            DropIndex("dbo.Stories", new[] { "Episode_EpisodeId" });
            DropIndex("dbo.GameEpisodes", new[] { "EpisodeId" });
            DropIndex("dbo.GameEpisodes", new[] { "GameId" });
            DropColumn("dbo.Stories", "Episode_EpisodeId");
            DropColumn("dbo.Stories", "IsDialogue");
            DropColumn("dbo.Stories", "IsLast");
            DropColumn("dbo.Stories", "IsFirst");
            DropTable("dbo.Episodes");
            DropTable("dbo.GameEpisodes");
        }
    }
}
