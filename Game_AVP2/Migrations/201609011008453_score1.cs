namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class score1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonsterAttributes", "Luck", c => c.Int(nullable: false));
            AddColumn("dbo.Attributes", "Luck", c => c.Int(nullable: false));
            AddColumn("dbo.CharacterAttributes", "Luck", c => c.Int(nullable: false));
            DropColumn("dbo.MonsterAttributes", "LuckModifier");
            DropColumn("dbo.Attributes", "LuckModifier");
            DropColumn("dbo.CharacterAttributes", "LuckModifier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CharacterAttributes", "LuckModifier", c => c.Int(nullable: false));
            AddColumn("dbo.Attributes", "LuckModifier", c => c.Int(nullable: false));
            AddColumn("dbo.MonsterAttributes", "LuckModifier", c => c.Int(nullable: false));
            DropColumn("dbo.CharacterAttributes", "Luck");
            DropColumn("dbo.Attributes", "Luck");
            DropColumn("dbo.MonsterAttributes", "Luck");
        }
    }
}
