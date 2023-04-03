namespace Mid_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectionAssigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignedTime = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                        FoodRequest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.FoodRequests", t => t.FoodRequest_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.FoodRequest_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.FoodRequests", "PerservationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionAssigns", "FoodRequest_Id", "dbo.FoodRequests");
            DropForeignKey("dbo.CollectionAssigns", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.CollectionAssigns", new[] { "FoodRequest_Id" });
            DropIndex("dbo.CollectionAssigns", new[] { "Employee_Id" });
            AlterColumn("dbo.FoodRequests", "PerservationTime", c => c.Time(nullable: false, precision: 7));
            DropTable("dbo.Employees");
            DropTable("dbo.CollectionAssigns");
        }
    }
}
