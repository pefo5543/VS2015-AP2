namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gameprops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "LastPlayed", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "LastPlayed");
        }
    }
}
