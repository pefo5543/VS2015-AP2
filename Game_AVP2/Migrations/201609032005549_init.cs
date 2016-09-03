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
                        CharacterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Experience = c.Int(nullable: false),
                        Credits = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Description = c.String(),
                        Background = c.String(),
                        StaticCharacterId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.StaticCharacters", t => t.StaticCharacterId, cascadeDelete: true)
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
                "dbo.CharacterArmours",
                c => new
                    {
                        CharacterArmourId = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        ArmourId = c.Int(nullable: false),
                        Equipped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterArmourId)
                .ForeignKey("dbo.Armours", t => t.ArmourId, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.CharacterId)
                .Index(t => t.ArmourId);
            
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
                        CharacterId = c.Int(nullable: false),
                        MiscId = c.Int(nullable: false),
                        Armour_ArmourId = c.Int(),
                    })
                .PrimaryKey(t => t.CharacterItemId)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Miscs", t => t.MiscId, cascadeDelete: true)
                .ForeignKey("dbo.Armours", t => t.Armour_ArmourId)
                .Index(t => t.CharacterId)
                .Index(t => t.MiscId)
                .Index(t => t.Armour_ArmourId);
            
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
                "dbo.Monsters",
                c => new
                    {
                        MonsterId = c.Int(nullable: false, identity: true),
                        AbilityID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        Background = c.String(),
                        EquippedWeaponId = c.Int(nullable: false),
                        EquippedArmourId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        Rarity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonsterId)
                .ForeignKey("dbo.Armours", t => t.EquippedArmourId, cascadeDelete: true)
                .ForeignKey("dbo.MonsterImages", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Weapons", t => t.EquippedWeaponId, cascadeDelete: true)
                .Index(t => t.EquippedWeaponId)
                .Index(t => t.EquippedArmourId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Battles",
                c => new
                    {
                        BattleId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        MonsterId = c.Int(nullable: false),
                        Rounds = c.Int(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BattleId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Monsters", t => t.MonsterId)
                .Index(t => t.GameId)
                .Index(t => t.MonsterId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        Progress = c.Int(nullable: false),
                        BattleCount = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        LastPlayed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Characters", t => t.GameId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.MonsterAttributes",
                c => new
                    {
                        MonsterId = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        Luck = c.Int(nullable: false),
                        DefenceModifier = c.Int(nullable: false),
                        StrengthModifier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonsterId)
                .ForeignKey("dbo.Monsters", t => t.MonsterId)
                .Index(t => t.MonsterId);
            
            CreateTable(
                "dbo.MonsterImages",
                c => new
                    {
                        MonsterImageId = c.Int(nullable: false, identity: true),
                        ImageLink = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        FileName = c.String(nullable: false),
                        ThumbnailLink = c.String(),
                    })
                .PrimaryKey(t => t.MonsterImageId);
            
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
                "dbo.CharacterWeapons",
                c => new
                    {
                        CharacterWeaponId = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        WeaponId = c.Int(nullable: false),
                        Equipped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterWeaponId)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .ForeignKey("dbo.Weapons", t => t.WeaponId, cascadeDelete: true)
                .Index(t => t.CharacterId)
                .Index(t => t.WeaponId);
            
            CreateTable(
                "dbo.StaticCharacters",
                c => new
                    {
                        StaticCharacterId = c.Int(nullable: false, identity: true),
                        AbilityID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        Background = c.String(),
                        EquippedWeaponId = c.Int(nullable: false),
                        EquippedArmourId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaticCharacterId)
                .ForeignKey("dbo.Armours", t => t.EquippedArmourId, cascadeDelete: true)
                .ForeignKey("dbo.CharacterImages", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Weapons", t => t.EquippedWeaponId, cascadeDelete: true)
                .Index(t => t.EquippedWeaponId)
                .Index(t => t.EquippedArmourId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        StaticCharacterId = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        Luck = c.Int(nullable: false),
                        DefenceModifier = c.Int(nullable: false),
                        StrengthModifier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaticCharacterId)
                .ForeignKey("dbo.StaticCharacters", t => t.StaticCharacterId, cascadeDelete: true)
                .Index(t => t.StaticCharacterId);
            
            CreateTable(
                "dbo.CharacterAttributes",
                c => new
                    {
                        CharacterId = c.Int(nullable: false),
                        AttributeId = c.Int(nullable: false),
                        HealthLeft = c.Int(nullable: false),
                        StaminaLeft = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        Luck = c.Int(nullable: false),
                        DefenceModifier = c.Int(nullable: false),
                        StrengthModifier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Attributes", t => t.AttributeId)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId)
                .Index(t => t.AttributeId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoryId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        IsBattle = c.Boolean(nullable: false),
                        NextText = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoryId);
            
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
                "dbo.MonsterAbilities",
                c => new
                    {
                        Monster_MonsterId = c.Int(nullable: false),
                        Ability_AbilityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Monster_MonsterId, t.Ability_AbilityId })
                .ForeignKey("dbo.Monsters", t => t.Monster_MonsterId, cascadeDelete: true)
                .ForeignKey("dbo.Abilities", t => t.Ability_AbilityId, cascadeDelete: true)
                .Index(t => t.Monster_MonsterId)
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
            DropForeignKey("dbo.CharacterArmours", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterArmours", "ArmourId", "dbo.Armours");
            DropForeignKey("dbo.Weapons", "ImageId", "dbo.WeaponImages");
            DropForeignKey("dbo.StaticCharacters", "EquippedWeaponId", "dbo.Weapons");
            DropForeignKey("dbo.Characters", "StaticCharacterId", "dbo.StaticCharacters");
            DropForeignKey("dbo.StaticCharacters", "ImageId", "dbo.CharacterImages");
            DropForeignKey("dbo.Attributes", "StaticCharacterId", "dbo.StaticCharacters");
            DropForeignKey("dbo.CharacterAttributes", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterAttributes", "AttributeId", "dbo.Attributes");
            DropForeignKey("dbo.StaticCharacters", "EquippedArmourId", "dbo.Armours");
            DropForeignKey("dbo.StaticCharacterAbilities", "Ability_AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.StaticCharacterAbilities", "StaticCharacter_StaticCharacterId", "dbo.StaticCharacters");
            DropForeignKey("dbo.Monsters", "EquippedWeaponId", "dbo.Weapons");
            DropForeignKey("dbo.CharacterWeapons", "WeaponId", "dbo.Weapons");
            DropForeignKey("dbo.CharacterWeapons", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Monsters", "ImageId", "dbo.MonsterImages");
            DropForeignKey("dbo.MonsterAttributes", "MonsterId", "dbo.Monsters");
            DropForeignKey("dbo.Battles", "MonsterId", "dbo.Monsters");
            DropForeignKey("dbo.Games", "GameId", "dbo.Characters");
            DropForeignKey("dbo.Battles", "GameId", "dbo.Games");
            DropForeignKey("dbo.Monsters", "EquippedArmourId", "dbo.Armours");
            DropForeignKey("dbo.MonsterAbilities", "Ability_AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.MonsterAbilities", "Monster_MonsterId", "dbo.Monsters");
            DropForeignKey("dbo.CharacterItems", "Armour_ArmourId", "dbo.Armours");
            DropForeignKey("dbo.CharacterItems", "MiscId", "dbo.Miscs");
            DropForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Armours", "ImageId", "dbo.ArmourImages");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Characters", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CharacterAbilities", "Ability_AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.CharacterAbilities", "Character_CharacterId", "dbo.Characters");
            DropIndex("dbo.StaticCharacterAbilities", new[] { "Ability_AbilityId" });
            DropIndex("dbo.StaticCharacterAbilities", new[] { "StaticCharacter_StaticCharacterId" });
            DropIndex("dbo.MonsterAbilities", new[] { "Ability_AbilityId" });
            DropIndex("dbo.MonsterAbilities", new[] { "Monster_MonsterId" });
            DropIndex("dbo.CharacterAbilities", new[] { "Ability_AbilityId" });
            DropIndex("dbo.CharacterAbilities", new[] { "Character_CharacterId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CharacterAttributes", new[] { "AttributeId" });
            DropIndex("dbo.CharacterAttributes", new[] { "CharacterId" });
            DropIndex("dbo.Attributes", new[] { "StaticCharacterId" });
            DropIndex("dbo.StaticCharacters", new[] { "ImageId" });
            DropIndex("dbo.StaticCharacters", new[] { "EquippedArmourId" });
            DropIndex("dbo.StaticCharacters", new[] { "EquippedWeaponId" });
            DropIndex("dbo.CharacterWeapons", new[] { "WeaponId" });
            DropIndex("dbo.CharacterWeapons", new[] { "CharacterId" });
            DropIndex("dbo.Weapons", new[] { "ImageId" });
            DropIndex("dbo.MonsterAttributes", new[] { "MonsterId" });
            DropIndex("dbo.Games", new[] { "GameId" });
            DropIndex("dbo.Battles", new[] { "MonsterId" });
            DropIndex("dbo.Battles", new[] { "GameId" });
            DropIndex("dbo.Monsters", new[] { "ImageId" });
            DropIndex("dbo.Monsters", new[] { "EquippedArmourId" });
            DropIndex("dbo.Monsters", new[] { "EquippedWeaponId" });
            DropIndex("dbo.CharacterItems", new[] { "Armour_ArmourId" });
            DropIndex("dbo.CharacterItems", new[] { "MiscId" });
            DropIndex("dbo.CharacterItems", new[] { "CharacterId" });
            DropIndex("dbo.Armours", new[] { "ImageId" });
            DropIndex("dbo.CharacterArmours", new[] { "ArmourId" });
            DropIndex("dbo.CharacterArmours", new[] { "CharacterId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Characters", new[] { "UserId" });
            DropIndex("dbo.Characters", new[] { "StaticCharacterId" });
            DropTable("dbo.StaticCharacterAbilities");
            DropTable("dbo.MonsterAbilities");
            DropTable("dbo.CharacterAbilities");
            DropTable("dbo.Stories");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.WeaponImages");
            DropTable("dbo.CharacterImages");
            DropTable("dbo.CharacterAttributes");
            DropTable("dbo.Attributes");
            DropTable("dbo.StaticCharacters");
            DropTable("dbo.CharacterWeapons");
            DropTable("dbo.Weapons");
            DropTable("dbo.MonsterImages");
            DropTable("dbo.MonsterAttributes");
            DropTable("dbo.Games");
            DropTable("dbo.Battles");
            DropTable("dbo.Monsters");
            DropTable("dbo.Miscs");
            DropTable("dbo.CharacterItems");
            DropTable("dbo.ArmourImages");
            DropTable("dbo.Armours");
            DropTable("dbo.CharacterArmours");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Characters");
            DropTable("dbo.Abilities");
        }
    }
}
