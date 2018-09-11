namespace Bootcamp_18.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Regencies_deletecolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Regencies", "Provinces_Id");
            RenameColumn(table: "dbo.Regencies", name: "Provinces_Id1", newName: "Provinces_Id");
            RenameIndex(table: "dbo.Regencies", name: "IX_Provinces_Id1", newName: "IX_Provinces_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Regencies", name: "IX_Provinces_Id", newName: "IX_Provinces_Id1");
            RenameColumn(table: "dbo.Regencies", name: "Provinces_Id", newName: "Provinces_Id1");
            AddColumn("dbo.Regencies", "Provinces_Id", c => c.Int());
        }
    }
}
