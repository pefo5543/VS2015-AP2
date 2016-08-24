namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class characteritems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterItems", "WeaponId", "dbo.Weapons");
            DropForeignKey("dbo.CharacterItems", "Misc_MiscId", "dbo.Miscs");
            DropIndex("dbo.CharacterItems", new[] { "CharacterId" });
            DropIndex("dbo.CharacterItems", new[] { "WeaponId" });
            DropIndex("dbo.CharacterItems", new[] { "Misc_MiscId" });
            RenameColumn(table: "dbo.CharacterItems", name: "ArmourId", newName: "Armour_ArmourId");
            RenameColumn(table: "dbo.CharacterItems", name: "Misc_MiscId", newName: "MiscId");
            RenameIndex(table: "dbo.CharacterItems", name: "IX_ArmourId", newName: "IX_Armour_ArmourId");
            CreateTable(
                "dbo.CharacterArmours",
                c => new
                    {
                        CharacterArmourId = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        ArmourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterArmourId)
                .ForeignKey("dbo.Armours", t => t.ArmourId, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: false)
                .Index(t => t.CharacterId)
                .Index(t => t.ArmourId);
            
            CreateTable(
                "dbo.CharacterWeapons",
                c => new
                    {
                        CharacterWeaponId = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        WeaponId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterWeaponId)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: false)
                .ForeignKey("dbo.Weapons", t => t.WeaponId, cascadeDelete: true)
                .Index(t => t.CharacterId)
                .Index(t => t.WeaponId);
            
            AddColumn("dbo.Characters", "EquippedWeaponId", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "EquippedArmourId", c => c.Int(nullable: false));
            AlterColumn("dbo.CharacterItems", "CharacterId", c => c.Int(nullable: false));
            AlterColumn("dbo.CharacterItems", "MiscId", c => c.Int(nullable: false));
            CreateIndex("dbo.CharacterItems", "CharacterId");
            CreateIndex("dbo.CharacterItems", "MiscId");
            AddForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters", "CharacterId", cascadeDelete: true);
            AddForeignKey("dbo.CharacterItems", "MiscId", "dbo.Miscs", "MiscId", cascadeDelete: true);
            DropColumn("dbo.CharacterItems", "WeaponId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CharacterItems", "WeaponId", c => c.Int());
            DropForeignKey("dbo.CharacterItems", "MiscId", "dbo.Miscs");
            DropForeignKey("dbo.CharacterWeapons", "WeaponId", "dbo.Weapons");
            DropForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterWeapons", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterArmours", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterArmours", "ArmourId", "dbo.Armours");
            DropIndex("dbo.CharacterWeapons", new[] { "WeaponId" });
            DropIndex("dbo.CharacterWeapons", new[] { "CharacterId" });
            DropIndex("dbo.CharacterItems", new[] { "MiscId" });
            DropIndex("dbo.CharacterItems", new[] { "CharacterId" });
            DropIndex("dbo.CharacterArmours", new[] { "ArmourId" });
            DropIndex("dbo.CharacterArmours", new[] { "CharacterId" });
            AlterColumn("dbo.CharacterItems", "MiscId", c => c.Int());
            AlterColumn("dbo.CharacterItems", "CharacterId", c => c.Int());
            DropColumn("dbo.Characters", "EquippedArmourId");
            DropColumn("dbo.Characters", "EquippedWeaponId");
            DropTable("dbo.CharacterWeapons");
            DropTable("dbo.CharacterArmours");
            RenameIndex(table: "dbo.CharacterItems", name: "IX_Armour_ArmourId", newName: "IX_ArmourId");
            RenameColumn(table: "dbo.CharacterItems", name: "MiscId", newName: "Misc_MiscId");
            RenameColumn(table: "dbo.CharacterItems", name: "Armour_ArmourId", newName: "ArmourId");
            CreateIndex("dbo.CharacterItems", "Misc_MiscId");
            CreateIndex("dbo.CharacterItems", "WeaponId");
            CreateIndex("dbo.CharacterItems", "CharacterId");
            AddForeignKey("dbo.CharacterItems", "Misc_MiscId", "dbo.Miscs", "MiscId");
            AddForeignKey("dbo.CharacterItems", "WeaponId", "dbo.Weapons", "WeaponId");
            AddForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters", "CharacterId");
        }
    }
}
