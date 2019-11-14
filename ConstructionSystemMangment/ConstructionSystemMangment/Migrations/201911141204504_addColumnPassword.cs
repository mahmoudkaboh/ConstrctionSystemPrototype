namespace ConstructionSystemMangment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Password");
        }
    }
}
