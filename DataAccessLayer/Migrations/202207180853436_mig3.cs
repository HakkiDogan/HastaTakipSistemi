namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Departments", "Status");
            DropColumn("dbo.VitalSigns", "Status");
            DropColumn("dbo.NormalRangeValues", "Status");
            DropColumn("dbo.Services", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.NormalRangeValues", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.VitalSigns", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Departments", "Status", c => c.Boolean(nullable: false));
        }
    }
}
