namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "DogumTarihi", c => c.String(maxLength: 10));
            AlterColumn("dbo.Patients", "DogumTarihi", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DogumTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Doctors", "DogumTarihi", c => c.DateTime(nullable: false));
        }
    }
}
