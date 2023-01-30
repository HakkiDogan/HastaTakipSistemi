namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "BolumID", "dbo.Departments");
            DropIndex("dbo.Doctors", new[] { "BolumID" });
            DropColumn("dbo.Doctors", "BolumID");
            DropTable("dbo.Departments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        BolumID = c.Int(nullable: false, identity: true),
                        BolumAdi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BolumID);
            
            AddColumn("dbo.Doctors", "BolumID", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "BolumID");
            AddForeignKey("dbo.Doctors", "BolumID", "dbo.Departments", "BolumID", cascadeDelete: true);
        }
    }
}
