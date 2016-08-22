namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Character : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "CharacterId", "dbo.CharacterAttributes");
            DropForeignKey("dbo.CharacterAbilities", "Character_CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters");
            DropIndex("dbo.Characters", new[] { "CharacterId" });
            DropPrimaryKey("dbo.Characters");
            DropPrimaryKey("dbo.CharacterAttributes");
            AddColumn("dbo.CharacterAttributes", "CharacterId", c => c.Int(nullable: false));
            AlterColumn("dbo.Characters", "CharacterId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Characters", "CharacterId");
            AddPrimaryKey("dbo.CharacterAttributes", "CharacterId");
            CreateIndex("dbo.CharacterAttributes", "CharacterId");
            AddForeignKey("dbo.CharacterAttributes", "CharacterId", "dbo.Characters", "CharacterId", cascadeDelete: true);
            AddForeignKey("dbo.CharacterAbilities", "Character_CharacterId", "dbo.Characters", "CharacterId", cascadeDelete: true);
            AddForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters", "CharacterId");
            DropColumn("dbo.CharacterAttributes", "CharacterAttributeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CharacterAttributes", "CharacterAttributeId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterAbilities", "Character_CharacterId", "dbo.Characters");
            DropForeignKey("dbo.CharacterAttributes", "CharacterId", "dbo.Characters");
            DropIndex("dbo.CharacterAttributes", new[] { "CharacterId" });
            DropPrimaryKey("dbo.CharacterAttributes");
            DropPrimaryKey("dbo.Characters");
            AlterColumn("dbo.Characters", "CharacterId", c => c.Int(nullable: false));
            DropColumn("dbo.CharacterAttributes", "CharacterId");
            AddPrimaryKey("dbo.CharacterAttributes", "CharacterAttributeId");
            AddPrimaryKey("dbo.Characters", "CharacterId");
            CreateIndex("dbo.Characters", "CharacterId");
            AddForeignKey("dbo.CharacterItems", "CharacterId", "dbo.Characters", "CharacterId");
            AddForeignKey("dbo.CharacterAbilities", "Character_CharacterId", "dbo.Characters", "CharacterId", cascadeDelete: true);
            AddForeignKey("dbo.Characters", "CharacterId", "dbo.CharacterAttributes", "CharacterAttributeId");
        }
    }
}
