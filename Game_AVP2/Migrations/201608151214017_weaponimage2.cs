namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weaponimage2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeaponImages", "FileName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeaponImages", "FileName");
        }
    }
}
