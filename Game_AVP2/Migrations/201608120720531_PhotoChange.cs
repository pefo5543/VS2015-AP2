namespace Game_AVP2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeaponPhotoes",
                c => new
                    {
                        WeaponId = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.WeaponId)
                .ForeignKey("dbo.Weapons", t => t.WeaponId)
                .Index(t => t.WeaponId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeaponPhotoes", "WeaponId", "dbo.Weapons");
            DropIndex("dbo.WeaponPhotoes", new[] { "WeaponId" });
            DropTable("dbo.WeaponPhotoes");
        }
    }
}
