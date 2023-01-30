namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DoktorMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Doctors", "DoktorSifre", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "DoktorSifre");
            DropColumn("dbo.Doctors", "DoktorMail");
        }
    }
}
