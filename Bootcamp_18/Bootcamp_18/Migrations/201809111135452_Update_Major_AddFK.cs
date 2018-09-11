namespace Bootcamp_18.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Major_AddFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Majors", "Faculties_Id", "dbo.Faculties");
            DropIndex("dbo.Majors", new[] { "Faculties_Id" });
            RenameColumn(table: "dbo.Majors", name: "Faculties_Id", newName: "FacultyId");
            AlterColumn("dbo.Majors", "FacultyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Majors", "FacultyId");
            AddForeignKey("dbo.Majors", "FacultyId", "dbo.Faculties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Majors", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.Majors", new[] { "FacultyId" });
            AlterColumn("dbo.Majors", "FacultyId", c => c.Int());
            RenameColumn(table: "dbo.Majors", name: "FacultyId", newName: "Faculties_Id");
            CreateIndex("dbo.Majors", "Faculties_Id");
            AddForeignKey("dbo.Majors", "Faculties_Id", "dbo.Faculties", "Id");
        }
    }
}
