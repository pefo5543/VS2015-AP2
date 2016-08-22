namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attributes", "StaticCharacterId", "dbo.StaticCharacters");
            DropForeignKey("dbo.StaticCharacters", "Attribute_StaticCharacterId", "dbo.Attributes");
            DropForeignKey("dbo.CharacterAttributes", "Attribute_StaticCharacterId", "dbo.Attributes");
            DropIndex("dbo.Attributes", new[] { "StaticCharacterId" });
            DropPrimaryKey("dbo.Attributes");
            AlterColumn("dbo.Attributes", "StaticCharacterId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Attributes", "StaticCharacterId");
            AddForeignKey("dbo.StaticCharacters", "Attribute_StaticCharacterId", "dbo.Attributes", "StaticCharacterId", cascadeDelete: true);
            AddForeignKey("dbo.CharacterAttributes", "Attribute_StaticCharacterId", "dbo.Attributes", "StaticCharacterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterAttributes", "Attribute_StaticCharacterId", "dbo.Attributes");
            DropForeignKey("dbo.StaticCharacters", "Attribute_StaticCharacterId", "dbo.Attributes");
            DropPrimaryKey("dbo.Attributes");
            AlterColumn("dbo.Attributes", "StaticCharacterId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Attributes", "StaticCharacterId");
            CreateIndex("dbo.Attributes", "StaticCharacterId");
            AddForeignKey("dbo.CharacterAttributes", "Attribute_StaticCharacterId", "dbo.Attributes", "StaticCharacterId");
            AddForeignKey("dbo.StaticCharacters", "Attribute_StaticCharacterId", "dbo.Attributes", "StaticCharacterId", cascadeDelete: true);
            AddForeignKey("dbo.Attributes", "StaticCharacterId", "dbo.StaticCharacters", "StaticCharacterId");
        }
    }
}
