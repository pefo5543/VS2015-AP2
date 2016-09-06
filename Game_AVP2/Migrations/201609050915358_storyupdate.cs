namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storyupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stories", "NextText", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stories", "NextText", c => c.Int(nullable: false));
        }
    }
}
