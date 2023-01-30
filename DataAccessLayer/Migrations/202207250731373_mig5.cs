namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientArrivals", "CıkısTarihi", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientArrivals", "CıkısTarihi", c => c.DateTime(nullable: false));
        }
    }
}
