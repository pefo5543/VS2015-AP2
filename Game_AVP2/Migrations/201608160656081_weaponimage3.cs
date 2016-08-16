namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weaponimage3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Weapons", "Image_WeaponImageId", "dbo.WeaponImages");
            DropIndex("dbo.Weapons", new[] { "Image_WeaponImageId" });
            RenameColumn(table: "dbo.Weapons", name: "Image_WeaponImageId", newName: "WeaponImageId");
            AlterColumn("dbo.Weapons", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Weapons", "WeaponImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Weapons", "WeaponImageId");
            AddForeignKey("dbo.Weapons", "WeaponImageId", "dbo.WeaponImages", "WeaponImageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapons", "WeaponImageId", "dbo.WeaponImages");
            DropIndex("dbo.Weapons", new[] { "WeaponImageId" });
            AlterColumn("dbo.Weapons", "WeaponImageId", c => c.Int());
            AlterColumn("dbo.Weapons", "Description", c => c.String());
            RenameColumn(table: "dbo.Weapons", name: "WeaponImageId", newName: "Image_WeaponImageId");
            CreateIndex("dbo.Weapons", "Image_WeaponImageId");
            AddForeignKey("dbo.Weapons", "Image_WeaponImageId", "dbo.WeaponImages", "WeaponImageId");
        }
    }
}
