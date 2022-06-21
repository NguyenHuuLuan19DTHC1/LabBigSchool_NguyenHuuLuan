namespace LabBigSchool_NguyenHuuLuan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        AttendaneeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseID, t.AttendaneeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendaneeId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .Index(t => t.CourseID)
                .Index(t => t.AttendaneeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "AttendaneeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendaneeId" });
            DropIndex("dbo.Attendances", new[] { "CourseID" });
            DropTable("dbo.Attendances");
        }
    }
}
