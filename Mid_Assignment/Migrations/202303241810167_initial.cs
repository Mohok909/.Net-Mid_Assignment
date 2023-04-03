namespace Mid_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerservationTime = c.Time(nullable: false, precision: 7),
                        Collected = c.Boolean(nullable: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodRequests", "ShopId", "dbo.Shops");
            DropIndex("dbo.FoodRequests", new[] { "ShopId" });
            DropTable("dbo.Shops");
            DropTable("dbo.FoodRequests");
        }
    }
}
