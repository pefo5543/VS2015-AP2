namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class episodeupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EpisodeRarities",
                c => new
                    {
                        EpisodeRarityId = c.Int(nullable: false, identity: true),
                        EpisodeId = c.Byte(nullable: false),
                        MonsterRarity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EpisodeRarityId)
                .ForeignKey("dbo.Episodes", t => t.EpisodeId, cascadeDelete: true)
                .Index(t => t.EpisodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EpisodeRarities", "EpisodeId", "dbo.Episodes");
            DropIndex("dbo.EpisodeRarities", new[] { "EpisodeId" });
            DropTable("dbo.EpisodeRarities");
        }
    }
}
