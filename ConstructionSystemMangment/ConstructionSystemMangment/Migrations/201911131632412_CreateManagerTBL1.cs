namespace ConstructionSystemMangment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateManagerTBL1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department Manager",
                c => new
                    {
                        MangerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DepartmentID = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MangerId)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Department Manager", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Department Manager", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Department Manager", new[] { "EmployeeId" });
            DropIndex("dbo.Department Manager", new[] { "DepartmentID" });
            DropTable("dbo.Department Manager");
        }
    }
}
