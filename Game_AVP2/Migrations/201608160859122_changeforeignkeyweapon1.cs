namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeforeignkeyweapon1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Weapons", "WeaponImageId", "dbo.WeaponImages");
            DropIndex("dbo.Weapons", new[] { "WeaponImageId" });
            RenameColumn(table: "dbo.Weapons", name: "WeaponImageId", newName: "WeaponImage_WeaponImageId");
            AddColumn("dbo.Weapons", "WeaponImgId", c => c.Int(nullable: false));
            AlterColumn("dbo.Weapons", "WeaponImage_WeaponImageId", c => c.Int());
            CreateIndex("dbo.Weapons", "WeaponImage_WeaponImageId");
            AddForeignKey("dbo.Weapons", "WeaponImage_WeaponImageId", "dbo.WeaponImages", "WeaponImageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapons", "WeaponImage_WeaponImageId", "dbo.WeaponImages");
            DropIndex("dbo.Weapons", new[] { "WeaponImage_WeaponImageId" });
            AlterColumn("dbo.Weapons", "WeaponImage_WeaponImageId", c => c.Int(nullable: false));
            DropColumn("dbo.Weapons", "WeaponImgId");
            RenameColumn(table: "dbo.Weapons", name: "WeaponImage_WeaponImageId", newName: "WeaponImageId");
            CreateIndex("dbo.Weapons", "WeaponImageId");
            AddForeignKey("dbo.Weapons", "WeaponImageId", "dbo.WeaponImages", "WeaponImageId", cascadeDelete: true);
        }
    }
}
