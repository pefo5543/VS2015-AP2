namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class score : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Score", c => c.Int(nullable: false));
            DropColumn("dbo.Characters", "Score");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "Score", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "Score");
        }
    }
}
