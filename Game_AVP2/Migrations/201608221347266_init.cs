namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        AbilityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.AbilityId);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Experience = c.Int(nullable: false),
                        Credits = c.Int(nullable: false),
                        StaticCharacterId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.StaticCharacters", t => t.StaticCharacterId, cascadeDelete: true)
                .ForeignKey("dbo.CharacterAttributes", t => t.CharacterId)
                .Index(t => t.CharacterId)
                .Index(t => t.StaticCharacterId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CharacterAttributes",
                c => new
                    {
                        CharacterAttributeId = c.Int(nullable: false, identity: true),
                        AttributeId = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        LuckModifier = c.Int(nullable: false),
                        DefenceModifier = c.Int(nullable: false),
                        StrengthModifier = c.Int(nullable: false),
                        Attribute_StaticCharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.CharacterAttributeId)
                .ForeignKey("dbo.Attributes", t => t.Attribute_StaticCharacterId)
                .Index(t => t.Attribute_StaticCharacterId);
            
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        StaticCharacterId = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        LuckModifier = c.Int(nullable: false),
                        DefenceModifier = c.Int(nullable: false),
                        StrengthModifier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaticCharacterId)
                .ForeignKey("dbo.StaticCharacters", t => t.StaticCharacterId)
                .Index(t => t.StaticCharacterId);
            
            CreateTable(
                "dbo.StaticCharacters",
                c => new
                    {
                        StaticCharacterId = c.Int(nullable: false, identity: true),
                        AbilityID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        EquippedWeaponId = c.Int(nullable: false),
                        EquippedArmourId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        Attribute_StaticCharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.StaticCharacterId)
                .ForeignKey("dbo.Weapons", t => t.EquippedWeaponId, cascadeDelete: true)
                .ForeignKey("dbo.Armours", t => t.EquippedArmourId, cascadeDelete: true)
                .ForeignKey("dbo.Attributes", t => t.Attribute_StaticCharacterId, cascadeDelete: true)
                .ForeignKey("dbo.CharacterImages", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.EquippedWeaponId)
                .Index(t => t.EquippedArmourId)
                .Index(t => t.ImageId)
                .Index(t => t.Attribute_StaticCharacterId);
            
            CreateTable(
                "dbo.Armours",
                c => new
                    {
                        ArmourId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(maxLength: 200),
                        ArmourType = c.String(nullable: false),
                        Defense = c.Int(nullable: false),
                        ExtraDefense = c.Int(nullable: false),
                        Rarity = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArmourId)
                .ForeignKey("dbo.ArmourImages", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.ArmourImages",
                c => new
                    {
                        ArmourImageId = c.Int(nullable: false, identity: true),
                        ImageLink = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        FileName = c.String(nullable: false),
                        ThumbnailLink = c.String(),
                    })
                .PrimaryKey(t => t.ArmourImageId);
            
            CreateTable(
                "dbo.CharacterItems",
                c => new
                    {
                        CharacterItemId = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(),
                        WeaponId = c.Int(),
                        ArmourId = c.Int(),
                        Misc_MiscId = c.Int(),
                    })
                .PrimaryKey(t => t.CharacterItemId)
                .ForeignKey("dbo.Armours", t => t.ArmourId)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .ForeignKey("dbo.Weapons", t => t.WeaponId)
                .ForeignKey("dbo.Miscs", t => t.Misc_MiscId)
                .Index(t => t.CharacterId)
                .Index(t => t.WeaponId)
                .Index(t => t.ArmourId)
                .Index(t => t.Misc_MiscId);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(maxLength: 200),
                        WeaponType = c.String(nullable: false),
                        Damage = c.Int(nullable: false),
                        ExtraDamage = c.Int(nullable: false),
                        Rarity = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeaponId)
                .ForeignKey("dbo.WeaponImages", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.WeaponImages",
                c => new
                    {
                        WeaponImageId = c.Int(nullable: false, identity: true),
                        ImageLink = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        FileName = c.String(nullable: false),
                        ThumbnailLink = c.String(),
                    })
                .PrimaryKey(t => t.WeaponImageId);
            
            CreateTable(
                "dbo.CharacterImages",
                c => new
                    {
                        CharacterImageId = c.Int(nullable: false, identity: true),
                        ImageLink = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        FileName = c.String(nullable: false),
                        ThumbnailLink = c.String(),
                    })
                .PrimaryKey(t => t.CharacterImageId);
            
            CreateTable(
                "dbo.Miscs",
                c => new
                    {
                        MiscId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        MiscType = c.String(nullable: false),
                        HealthBonus = c.Int(nullable: false),
                        Rarity = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MiscId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CharacterAbilities",
                c => new
                    {
                        Character_CharacterId = c.Int(nullable: false),
                        Ability_AbilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Character_CharacterId, t.Ability_AbilityId })
                .ForeignKey("dbo.Characters", t => t.Character_CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Abilities", t => t.Ability_AbilityId, cascadeDelete: true)
                .Index(t => t.Character_CharacterId)
                .Index(t => t.Ability_AbilityId);
            
            CreateTable(
                "dbo.StaticCharacterAbilities",
                c => new
                    {
                        StaticCharacter_StaticCharacterId = c.Int(nullable: false),
                        Ability_AbilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StaticCharacter_StaticCharacterId, t.Ability_AbilityId })
                .ForeignKey("dbo.StaticCharacters", t => t.StaticCharacter_StaticCharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Abilities", t => t.Ability_AbilityId, cascadeDelete: true)
                .Index(t => t.StaticCharacter_StaticCharacterId)
                .Index(t => t.Ability_AbilityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CharacterItems", "Misc_MiscId", "dbo.Miscs");
            DropForeignKey("dbo.Characters", "CharacterId", "dbo.CharacterAttributes");
            DropForeignKey("dbo.CharacterAttributes", "Attribute_StaticCharacterId", "dbo.Attributes");
            DropForeignKey("dbo.Attributes", "StaticCharacterId", "dbo.StaticCharacters");
            DropForeignKey("dbo.Characters", "StaticCharacterId", "dbo.StaticCharacters");
            DropForeignKey("dbo.StaticCharacters", "ImageId", "dbo.CharacterImages");
            DropForeignKey("dbo.StaticCharacters", "Attribute_StaticCharacterId", "dbo.Attributes");
            DropForeignKey("dbo.StaticCharacters", "EquippedArmourId", "dbo.Armours");
            DropForeignKey("dbo.Weapons", "ImageId", "dbo.WeaponImages");
            DropForeignKey("dbo.StaticCharacters", "EquippedWeaponId", "dbo.Weapons");
            DropForeignKey("dbo.CharacterItems", "WeaponId", "dbo.Weapons");
            DropForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterItems", "ArmourId", "dbo.Armours");
            DropForeignKey("dbo.Armours", "ImageId", "dbo.ArmourImages");
            DropForeignKey("dbo.StaticCharacterAbilities", "Ability_AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.StaticCharacterAbilities", "StaticCharacter_StaticCharacterId", "dbo.StaticCharacters");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Characters", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CharacterAbilities", "Ability_AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.CharacterAbilities", "Character_CharacterId", "dbo.Characters");
            DropIndex("dbo.StaticCharacterAbilities", new[] { "Ability_AbilityId" });
            DropIndex("dbo.StaticCharacterAbilities", new[] { "StaticCharacter_StaticCharacterId" });
            DropIndex("dbo.CharacterAbilities", new[] { "Ability_AbilityId" });
            DropIndex("dbo.CharacterAbilities", new[] { "Character_CharacterId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Weapons", new[] { "ImageId" });
            DropIndex("dbo.CharacterItems", new[] { "Misc_MiscId" });
            DropIndex("dbo.CharacterItems", new[] { "ArmourId" });
            DropIndex("dbo.CharacterItems", new[] { "WeaponId" });
            DropIndex("dbo.CharacterItems", new[] { "CharacterId" });
            DropIndex("dbo.Armours", new[] { "ImageId" });
            DropIndex("dbo.StaticCharacters", new[] { "Attribute_StaticCharacterId" });
            DropIndex("dbo.StaticCharacters", new[] { "ImageId" });
            DropIndex("dbo.StaticCharacters", new[] { "EquippedArmourId" });
            DropIndex("dbo.StaticCharacters", new[] { "EquippedWeaponId" });
            DropIndex("dbo.Attributes", new[] { "StaticCharacterId" });
            DropIndex("dbo.CharacterAttributes", new[] { "Attribute_StaticCharacterId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Characters", new[] { "UserId" });
            DropIndex("dbo.Characters", new[] { "StaticCharacterId" });
            DropIndex("dbo.Characters", new[] { "CharacterId" });
            DropTable("dbo.StaticCharacterAbilities");
            DropTable("dbo.CharacterAbilities");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Miscs");
            DropTable("dbo.CharacterImages");
            DropTable("dbo.WeaponImages");
            DropTable("dbo.Weapons");
            DropTable("dbo.CharacterItems");
            DropTable("dbo.ArmourImages");
            DropTable("dbo.Armours");
            DropTable("dbo.StaticCharacters");
            DropTable("dbo.Attributes");
            DropTable("dbo.CharacterAttributes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Characters");
            DropTable("dbo.Abilities");
        }
    }
}
