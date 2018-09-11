namespace Bootcamp_18.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegencyAddNewColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regencies", "IdProvince", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regencies", "IdProvince");
        }
    }
}
