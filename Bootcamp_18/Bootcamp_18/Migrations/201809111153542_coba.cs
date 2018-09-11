namespace Bootcamp_18.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coba : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Majors", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.Majors", new[] { "FacultyId" });
            RenameColumn(table: "dbo.Majors", name: "FacultyId", newName: "Faculties_Id");
            AlterColumn("dbo.Majors", "Faculties_Id", c => c.Int());
            CreateIndex("dbo.Majors", "Faculties_Id");
            AddForeignKey("dbo.Majors", "Faculties_Id", "dbo.Faculties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Majors", "Faculties_Id", "dbo.Faculties");
            DropIndex("dbo.Majors", new[] { "Faculties_Id" });
            AlterColumn("dbo.Majors", "Faculties_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Majors", name: "Faculties_Id", newName: "FacultyId");
            CreateIndex("dbo.Majors", "FacultyId");
            AddForeignKey("dbo.Majors", "FacultyId", "dbo.Faculties", "Id", cascadeDelete: true);
        }
    }
}
