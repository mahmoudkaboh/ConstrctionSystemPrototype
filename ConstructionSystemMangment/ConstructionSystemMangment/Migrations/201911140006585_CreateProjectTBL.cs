namespace ConstructionSystemMangment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProjectTBL : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DepartmentLocation", newName: "Department Location");
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Location = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        ExpectedPeriod = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Project");
            RenameTable(name: "dbo.Department Location", newName: "DepartmentLocation");
        }
    }
}
