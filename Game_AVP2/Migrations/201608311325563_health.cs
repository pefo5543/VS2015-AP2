namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class health : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharacterAttributes", "HealthLeft", c => c.Int(nullable: false));
            AddColumn("dbo.CharacterAttributes", "StaminaLeft", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CharacterAttributes", "StaminaLeft");
            DropColumn("dbo.CharacterAttributes", "HealthLeft");
        }
    }
}
