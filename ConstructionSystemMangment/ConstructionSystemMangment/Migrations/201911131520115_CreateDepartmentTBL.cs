namespace ConstructionSystemMangment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDepartmentTBL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        NumberOfEmps = c.Int(),
                        StartDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            AddColumn("dbo.Employee", "Phone", c => c.String(maxLength: 15));
            AddColumn("dbo.Employee", "HireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employee", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Email");
            DropColumn("dbo.Employee", "HireDate");
            DropColumn("dbo.Employee", "Phone");
            DropTable("dbo.Department");
        }
    }
}
