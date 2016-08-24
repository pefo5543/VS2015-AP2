namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backgroundcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Background", c => c.String());
            AddColumn("dbo.StaticCharacters", "Background", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StaticCharacters", "Background");
            DropColumn("dbo.Characters", "Background");
        }
    }
}
