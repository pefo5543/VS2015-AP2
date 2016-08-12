namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemsnewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Armours", "Rarity", c => c.Int(nullable: false));
            AddColumn("dbo.Armours", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.Miscs", "Rarity", c => c.Int(nullable: false));
            AddColumn("dbo.Miscs", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.Weapons", "Rarity", c => c.Int(nullable: false));
            AddColumn("dbo.Weapons", "Value", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weapons", "Value");
            DropColumn("dbo.Weapons", "Rarity");
            DropColumn("dbo.Miscs", "Value");
            DropColumn("dbo.Miscs", "Rarity");
            DropColumn("dbo.Armours", "Value");
            DropColumn("dbo.Armours", "Rarity");
        }
    }
}
