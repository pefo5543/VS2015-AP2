namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weaponimage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeaponImages", "Name", c => c.String(nullable: false));
            DropColumn("dbo.WeaponImages", "ImageDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WeaponImages", "ImageDescription", c => c.String(nullable: false));
            DropColumn("dbo.WeaponImages", "Name");
        }
    }
}
