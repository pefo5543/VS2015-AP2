namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storyupdate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stories", "Episode_EpisodeId", "dbo.Episodes");
            DropIndex("dbo.Stories", new[] { "Episode_EpisodeId" });
            RenameColumn(table: "dbo.Stories", name: "Episode_EpisodeId", newName: "EpisodeId");
            AlterColumn("dbo.Stories", "EpisodeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Stories", "EpisodeId");
            AddForeignKey("dbo.Stories", "EpisodeId", "dbo.Episodes", "EpisodeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stories", "EpisodeId", "dbo.Episodes");
            DropIndex("dbo.Stories", new[] { "EpisodeId" });
            AlterColumn("dbo.Stories", "EpisodeId", c => c.Byte());
            RenameColumn(table: "dbo.Stories", name: "EpisodeId", newName: "Episode_EpisodeId");
            CreateIndex("dbo.Stories", "Episode_EpisodeId");
            AddForeignKey("dbo.Stories", "Episode_EpisodeId", "dbo.Episodes", "EpisodeId");
        }
    }
}
