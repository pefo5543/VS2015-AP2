namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class characteritems2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharacterArmours", "Equipped", c => c.Boolean(nullable: false));
            AddColumn("dbo.CharacterWeapons", "Equipped", c => c.Boolean(nullable: false));
            DropColumn("dbo.Characters", "EquippedWeaponId");
            DropColumn("dbo.Characters", "EquippedArmourId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "EquippedArmourId", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "EquippedWeaponId", c => c.Int(nullable: false));
            DropColumn("dbo.CharacterWeapons", "Equipped");
            DropColumn("dbo.CharacterArmours", "Equipped");
        }
    }
}
