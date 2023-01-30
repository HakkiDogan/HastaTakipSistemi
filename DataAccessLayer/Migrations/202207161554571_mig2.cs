namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NormalRangeValues", "MinYas", c => c.Int(nullable: false));
            AddColumn("dbo.NormalRangeValues", "MaxYas", c => c.Int(nullable: false));
            DropColumn("dbo.NormalRangeValues", "Yas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NormalRangeValues", "Yas", c => c.Int(nullable: false));
            DropColumn("dbo.NormalRangeValues", "MaxYas");
            DropColumn("dbo.NormalRangeValues", "MinYas");
        }
    }
}
