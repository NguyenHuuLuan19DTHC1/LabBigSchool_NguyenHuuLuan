namespace LabBigSchool_NguyenHuuLuan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropColumn("dbo.Courses", "CategoryId");
            RenameColumn(table: "dbo.Courses", name: "Category_Id", newName: "CategoryId");
            AddColumn("dbo.Courses", "Place", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Courses", "CategoryId");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            Sql("INSERT INTO CATEGORIES (ID, NAME) VALUES (1,'Development')");
            Sql("INSERT INTO CATEGORIES (ID, NAME) VALUES (2,'Business')");
            Sql("INSERT INTO CATEGORIES (ID, NAME) VALUES (3,'Maketing')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte());
            AlterColumn("dbo.Courses", "CategoryId", c => c.Binary(nullable: false));
            DropColumn("dbo.Courses", "Place");
            RenameColumn(table: "dbo.Courses", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.Courses", "CategoryId", c => c.Binary(nullable: false));
            CreateIndex("dbo.Courses", "Category_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
