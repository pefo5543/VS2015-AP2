namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeagainweapon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Weapons", "WeaponImage_WeaponImageId", "dbo.WeaponImages");
            DropIndex("dbo.Weapons", new[] { "WeaponImage_WeaponImageId" });
            RenameColumn(table: "dbo.Weapons", name: "WeaponImage_WeaponImageId", newName: "WeaponImageId");
            AlterColumn("dbo.Weapons", "WeaponImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Weapons", "WeaponImageId");
            AddForeignKey("dbo.Weapons", "WeaponImageId", "dbo.WeaponImages", "WeaponImageId", cascadeDelete: true);
            DropColumn("dbo.Weapons", "WeaponImgId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weapons", "WeaponImgId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Weapons", "WeaponImageId", "dbo.WeaponImages");
            DropIndex("dbo.Weapons", new[] { "WeaponImageId" });
            AlterColumn("dbo.Weapons", "WeaponImageId", c => c.Int());
            RenameColumn(table: "dbo.Weapons", name: "WeaponImageId", newName: "WeaponImage_WeaponImageId");
            CreateIndex("dbo.Weapons", "WeaponImage_WeaponImageId");
            AddForeignKey("dbo.Weapons", "WeaponImage_WeaponImageId", "dbo.WeaponImages", "WeaponImageId");
        }
    }
}
