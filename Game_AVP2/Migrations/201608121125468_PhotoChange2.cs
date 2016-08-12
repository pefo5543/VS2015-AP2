namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoChange2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WeaponPhotoes", "WeaponId", "dbo.Weapons");
            DropIndex("dbo.WeaponPhotoes", new[] { "WeaponId" });
            DropPrimaryKey("dbo.WeaponPhotoes");
            AlterColumn("dbo.WeaponPhotoes", "WeaponId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.WeaponPhotoes", "WeaponId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.WeaponPhotoes");
            AlterColumn("dbo.WeaponPhotoes", "WeaponId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.WeaponPhotoes", "WeaponId");
            CreateIndex("dbo.WeaponPhotoes", "WeaponId");
            AddForeignKey("dbo.WeaponPhotoes", "WeaponId", "dbo.Weapons", "WeaponId");
        }
    }
}
