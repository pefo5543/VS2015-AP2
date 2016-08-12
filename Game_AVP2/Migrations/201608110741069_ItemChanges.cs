namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Armours", "ItemId", "dbo.Items");
            DropForeignKey("dbo.CharacterItems", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.Miscs", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Weapons", "ItemId", "dbo.Items");
            DropIndex("dbo.Armours", new[] { "ItemId" });
            DropIndex("dbo.CharacterItems", new[] { "Item_ItemId" });
            DropIndex("dbo.Miscs", new[] { "ItemId" });
            DropIndex("dbo.Weapons", new[] { "ItemId" });
            AddColumn("dbo.Armours", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Armours", "Description", c => c.String());
            AddColumn("dbo.CharacterItems", "Armour_ArmourId", c => c.Int());
            AddColumn("dbo.CharacterItems", "Misc_MiscId", c => c.Int());
            AddColumn("dbo.CharacterItems", "StaticCharacter_StaticCharacterId", c => c.Int());
            AddColumn("dbo.CharacterItems", "Weapon_WeaponId", c => c.Int());
            AddColumn("dbo.Miscs", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Miscs", "Description", c => c.String());
            AddColumn("dbo.Weapons", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Weapons", "Description", c => c.String());
            CreateIndex("dbo.CharacterItems", "Armour_ArmourId");
            CreateIndex("dbo.CharacterItems", "Misc_MiscId");
            CreateIndex("dbo.CharacterItems", "StaticCharacter_StaticCharacterId");
            CreateIndex("dbo.CharacterItems", "Weapon_WeaponId");
            AddForeignKey("dbo.CharacterItems", "Armour_ArmourId", "dbo.Armours", "ArmourId");
            AddForeignKey("dbo.CharacterItems", "Misc_MiscId", "dbo.Miscs", "MiscId");
            AddForeignKey("dbo.CharacterItems", "StaticCharacter_StaticCharacterId", "dbo.StaticCharacters", "StaticCharacterId");
            AddForeignKey("dbo.CharacterItems", "Weapon_WeaponId", "dbo.Weapons", "WeaponId");
            DropColumn("dbo.Armours", "ItemId");
            DropColumn("dbo.CharacterItems", "Item_ItemId");
            DropColumn("dbo.Miscs", "ItemId");
            DropColumn("dbo.Weapons", "ItemId");
            DropTable("dbo.Items");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            AddColumn("dbo.Weapons", "ItemId", c => c.Int());
            AddColumn("dbo.Miscs", "ItemId", c => c.Int());
            AddColumn("dbo.CharacterItems", "Item_ItemId", c => c.Int());
            AddColumn("dbo.Armours", "ItemId", c => c.Int());
            DropForeignKey("dbo.CharacterItems", "Weapon_WeaponId", "dbo.Weapons");
            DropForeignKey("dbo.CharacterItems", "StaticCharacter_StaticCharacterId", "dbo.StaticCharacters");
            DropForeignKey("dbo.CharacterItems", "Misc_MiscId", "dbo.Miscs");
            DropForeignKey("dbo.CharacterItems", "Armour_ArmourId", "dbo.Armours");
            DropIndex("dbo.CharacterItems", new[] { "Weapon_WeaponId" });
            DropIndex("dbo.CharacterItems", new[] { "StaticCharacter_StaticCharacterId" });
            DropIndex("dbo.CharacterItems", new[] { "Misc_MiscId" });
            DropIndex("dbo.CharacterItems", new[] { "Armour_ArmourId" });
            DropColumn("dbo.Weapons", "Description");
            DropColumn("dbo.Weapons", "Name");
            DropColumn("dbo.Miscs", "Description");
            DropColumn("dbo.Miscs", "Name");
            DropColumn("dbo.CharacterItems", "Weapon_WeaponId");
            DropColumn("dbo.CharacterItems", "StaticCharacter_StaticCharacterId");
            DropColumn("dbo.CharacterItems", "Misc_MiscId");
            DropColumn("dbo.CharacterItems", "Armour_ArmourId");
            DropColumn("dbo.Armours", "Description");
            DropColumn("dbo.Armours", "Name");
            CreateIndex("dbo.Weapons", "ItemId");
            CreateIndex("dbo.Miscs", "ItemId");
            CreateIndex("dbo.CharacterItems", "Item_ItemId");
            CreateIndex("dbo.Armours", "ItemId");
            AddForeignKey("dbo.Weapons", "ItemId", "dbo.Items", "ItemId");
            AddForeignKey("dbo.Miscs", "ItemId", "dbo.Items", "ItemId");
            AddForeignKey("dbo.CharacterItems", "Item_ItemId", "dbo.Items", "ItemId");
            AddForeignKey("dbo.Armours", "ItemId", "dbo.Items", "ItemId");
        }
    }
}
