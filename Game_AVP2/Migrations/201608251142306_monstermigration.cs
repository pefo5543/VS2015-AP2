namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class monstermigration : DbMigration
    {
        public override void Up()
        {
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
                        LuckModifier = c.Int(nullable: false),
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
            
            AddColumn("dbo.Characters", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Monsters", "EquippedWeaponId", "dbo.Weapons");
            DropForeignKey("dbo.Monsters", "ImageId", "dbo.MonsterImages");
            DropForeignKey("dbo.MonsterAttributes", "MonsterId", "dbo.Monsters");
            DropForeignKey("dbo.Battles", "MonsterId", "dbo.Monsters");
            DropForeignKey("dbo.Games", "GameId", "dbo.Characters");
            DropForeignKey("dbo.Battles", "GameId", "dbo.Games");
            DropForeignKey("dbo.Monsters", "EquippedArmourId", "dbo.Armours");
            DropForeignKey("dbo.MonsterAbilities", "Ability_AbilityId", "dbo.Abilities");
            DropForeignKey("dbo.MonsterAbilities", "Monster_MonsterId", "dbo.Monsters");
            DropIndex("dbo.MonsterAbilities", new[] { "Ability_AbilityId" });
            DropIndex("dbo.MonsterAbilities", new[] { "Monster_MonsterId" });
            DropIndex("dbo.MonsterAttributes", new[] { "MonsterId" });
            DropIndex("dbo.Games", new[] { "GameId" });
            DropIndex("dbo.Battles", new[] { "MonsterId" });
            DropIndex("dbo.Battles", new[] { "GameId" });
            DropIndex("dbo.Monsters", new[] { "ImageId" });
            DropIndex("dbo.Monsters", new[] { "EquippedArmourId" });
            DropIndex("dbo.Monsters", new[] { "EquippedWeaponId" });
            DropColumn("dbo.Characters", "Description");
            DropTable("dbo.MonsterAbilities");
            DropTable("dbo.MonsterImages");
            DropTable("dbo.MonsterAttributes");
            DropTable("dbo.Games");
            DropTable("dbo.Battles");
            DropTable("dbo.Monsters");
        }
    }
}
