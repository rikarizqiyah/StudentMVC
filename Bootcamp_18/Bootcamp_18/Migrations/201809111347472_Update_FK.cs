namespace Bootcamp_18.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_FK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Districts", "Regencies_Id", "dbo.Regencies");
            DropForeignKey("dbo.Regencies", "Provinces_Id", "dbo.Provinces");
            DropForeignKey("dbo.Students", "Majors_Id", "dbo.Majors");
            DropForeignKey("dbo.Students", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Villages", "Districts_Id", "dbo.Districts");
            DropIndex("dbo.Districts", new[] { "Regencies_Id" });
            DropIndex("dbo.Regencies", new[] { "Provinces_Id" });
            DropIndex("dbo.Students", new[] { "Majors_Id" });
            DropIndex("dbo.Students", new[] { "Villages_Id" });
            DropIndex("dbo.Villages", new[] { "Districts_Id" });
            RenameColumn(table: "dbo.Districts", name: "Regencies_Id", newName: "RegencyId");
            RenameColumn(table: "dbo.Regencies", name: "Provinces_Id", newName: "ProvinceId");
            RenameColumn(table: "dbo.Students", name: "Majors_Id", newName: "MajorId");
            RenameColumn(table: "dbo.Students", name: "Villages_Id", newName: "VillageId");
            RenameColumn(table: "dbo.Villages", name: "Districts_Id", newName: "DistrictId");
            AlterColumn("dbo.Districts", "RegencyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Regencies", "ProvinceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "MajorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "VillageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Villages", "DistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.Districts", "RegencyId");
            CreateIndex("dbo.Regencies", "ProvinceId");
            CreateIndex("dbo.Students", "MajorId");
            CreateIndex("dbo.Students", "VillageId");
            CreateIndex("dbo.Villages", "DistrictId");
            AddForeignKey("dbo.Districts", "RegencyId", "dbo.Regencies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Regencies", "ProvinceId", "dbo.Provinces", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "MajorId", "dbo.Majors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "VillageId", "dbo.Villages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Villages", "DistrictId", "dbo.Districts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Villages", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Students", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.Students", "MajorId", "dbo.Majors");
            DropForeignKey("dbo.Regencies", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Districts", "RegencyId", "dbo.Regencies");
            DropIndex("dbo.Villages", new[] { "DistrictId" });
            DropIndex("dbo.Students", new[] { "VillageId" });
            DropIndex("dbo.Students", new[] { "MajorId" });
            DropIndex("dbo.Regencies", new[] { "ProvinceId" });
            DropIndex("dbo.Districts", new[] { "RegencyId" });
            AlterColumn("dbo.Villages", "DistrictId", c => c.Int());
            AlterColumn("dbo.Students", "VillageId", c => c.Int());
            AlterColumn("dbo.Students", "MajorId", c => c.Int());
            AlterColumn("dbo.Regencies", "ProvinceId", c => c.Int());
            AlterColumn("dbo.Districts", "RegencyId", c => c.Int());
            RenameColumn(table: "dbo.Villages", name: "DistrictId", newName: "Districts_Id");
            RenameColumn(table: "dbo.Students", name: "VillageId", newName: "Villages_Id");
            RenameColumn(table: "dbo.Students", name: "MajorId", newName: "Majors_Id");
            RenameColumn(table: "dbo.Regencies", name: "ProvinceId", newName: "Provinces_Id");
            RenameColumn(table: "dbo.Districts", name: "RegencyId", newName: "Regencies_Id");
            CreateIndex("dbo.Villages", "Districts_Id");
            CreateIndex("dbo.Students", "Villages_Id");
            CreateIndex("dbo.Students", "Majors_Id");
            CreateIndex("dbo.Regencies", "Provinces_Id");
            CreateIndex("dbo.Districts", "Regencies_Id");
            AddForeignKey("dbo.Villages", "Districts_Id", "dbo.Districts", "Id");
            AddForeignKey("dbo.Students", "Villages_Id", "dbo.Villages", "Id");
            AddForeignKey("dbo.Students", "Majors_Id", "dbo.Majors", "Id");
            AddForeignKey("dbo.Regencies", "Provinces_Id", "dbo.Provinces", "Id");
            AddForeignKey("dbo.Districts", "Regencies_Id", "dbo.Regencies", "Id");
        }
    }
}
