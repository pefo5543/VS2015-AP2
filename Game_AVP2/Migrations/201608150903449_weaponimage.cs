namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weaponimage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeaponImages",
                c => new
                    {
                        WeaponImageId = c.Int(nullable: false, identity: true),
                        ImageLink = c.String(nullable: false),
                        ImageDescription = c.String(nullable: false),
                        ThumbnailLink = c.String(),
                    })
                .PrimaryKey(t => t.WeaponImageId);
            
            AddColumn("dbo.Weapons", "Image_WeaponImageId", c => c.Int());
            CreateIndex("dbo.Weapons", "Image_WeaponImageId");
            AddForeignKey("dbo.Weapons", "Image_WeaponImageId", "dbo.WeaponImages", "WeaponImageId");
            DropTable("dbo.WeaponPhotoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WeaponPhotoes",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.WeaponId);
            
            DropForeignKey("dbo.Weapons", "Image_WeaponImageId", "dbo.WeaponImages");
            DropIndex("dbo.Weapons", new[] { "Image_WeaponImageId" });
            DropColumn("dbo.Weapons", "Image_WeaponImageId");
            DropTable("dbo.WeaponImages");
        }
    }
}
