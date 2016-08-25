namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyca : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CharacterAttributes", new[] { "Attribute_StaticCharacterId" });
            DropColumn("dbo.CharacterAttributes", "AttributeId");
            RenameColumn(table: "dbo.CharacterAttributes", name: "Attribute_StaticCharacterId", newName: "AttributeId");
            AlterColumn("dbo.CharacterAttributes", "AttributeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CharacterAttributes", "AttributeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CharacterAttributes", new[] { "AttributeId" });
            AlterColumn("dbo.CharacterAttributes", "AttributeId", c => c.Int());
            RenameColumn(table: "dbo.CharacterAttributes", name: "AttributeId", newName: "Attribute_StaticCharacterId");
            AddColumn("dbo.CharacterAttributes", "AttributeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CharacterAttributes", "Attribute_StaticCharacterId");
        }
    }
}
