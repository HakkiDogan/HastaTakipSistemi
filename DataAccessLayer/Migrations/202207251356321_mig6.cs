namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VitalSignMeasurementValues", "OlcumZamani", c => c.DateTime(nullable: false));
            DropColumn("dbo.VitalSignMeasurementValues", "OlcumTarihi");
            DropColumn("dbo.VitalSignMeasurementValues", "OlcumSaati");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VitalSignMeasurementValues", "OlcumSaati", c => c.DateTime(nullable: false));
            AddColumn("dbo.VitalSignMeasurementValues", "OlcumTarihi", c => c.DateTime(nullable: false));
            DropColumn("dbo.VitalSignMeasurementValues", "OlcumZamani");
        }
    }
}
