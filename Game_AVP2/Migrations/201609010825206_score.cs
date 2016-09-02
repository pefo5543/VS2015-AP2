namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class score : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Score", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "Level");
            DropColumn("dbo.Characters", "Score");
        }
    }
}
