namespace ConstructionSystemMangment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateManagerTBL : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employee", name: "SuperId", newName: "employee_EmployeeId");
            RenameIndex(table: "dbo.Employee", name: "IX_SuperId", newName: "IX_employee_EmployeeId");
            AddColumn("dbo.Employee", "Department_DepartmentID", c => c.Int());
            CreateIndex("dbo.Employee", "Department_DepartmentID");
            AddForeignKey("dbo.Employee", "Department_DepartmentID", "dbo.Department", "DepartmentID");
            DropColumn("dbo.Department", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Department", "StartDate", c => c.DateTime());
            DropForeignKey("dbo.Employee", "Department_DepartmentID", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_DepartmentID" });
            DropColumn("dbo.Employee", "Department_DepartmentID");
            RenameIndex(table: "dbo.Employee", name: "IX_employee_EmployeeId", newName: "IX_SuperId");
            RenameColumn(table: "dbo.Employee", name: "employee_EmployeeId", newName: "SuperId");
        }
    }
}
