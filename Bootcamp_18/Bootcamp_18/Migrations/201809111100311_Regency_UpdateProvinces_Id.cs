namespace Bootcamp_18.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Regency_UpdateProvinces_Id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regencies", "Provinces_Id", "dbo.Provinces");
            DropIndex("dbo.Regencies", new[] { "Provinces_Id" });
            AddColumn("dbo.Regencies", "Provinces_Id1", c => c.Int());
            CreateIndex("dbo.Regencies", "Provinces_Id1");
            AddForeignKey("dbo.Regencies", "Provinces_Id1", "dbo.Provinces", "Id");
            DropColumn("dbo.Regencies", "IdProvince");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regencies", "IdProvince", c => c.Int(nullable: false));
            DropForeignKey("dbo.Regencies", "Provinces_Id1", "dbo.Provinces");
            DropIndex("dbo.Regencies", new[] { "Provinces_Id1" });
            DropColumn("dbo.Regencies", "Provinces_Id1");
            CreateIndex("dbo.Regencies", "Provinces_Id");
            AddForeignKey("dbo.Regencies", "Provinces_Id", "dbo.Provinces", "Id");
        }
    }
}
