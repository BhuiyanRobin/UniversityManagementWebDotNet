namespace UniversityManagementWebDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniId = c.String(),
                        Name = c.String(),
                        Nickname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseAssigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SemisterId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Section = c.Int(nullable: false),
                        TimeSlotId = c.Int(nullable: false),
                        WeekDaysId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Semisters", t => t.SemisterId, cascadeDelete: true)
                .ForeignKey("dbo.TimeSlots", t => t.TimeSlotId, cascadeDelete: true)
                .ForeignKey("dbo.WeekDays", t => t.WeekDaysId, cascadeDelete: true)
                .Index(t => t.SemisterId)
                .Index(t => t.CourseId)
                .Index(t => t.TimeSlotId)
                .Index(t => t.WeekDaysId)
                .Index(t => t.RoomId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseCode = c.String(nullable: false),
                        CourseCredit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false),
                        FacultyCode = c.String(nullable: false),
                        FacultyEmail = c.String(nullable: false),
                        FacultyContactNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(nullable: false),
                        RoomNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Semisters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Years = c.Int(nullable: false),
                        SemistereName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeSlots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeForm = c.Time(nullable: false, precision: 7),
                        TimeTo = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeekDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperatorId = c.Int(nullable: false),
                        SenderId = c.String(),
                        Messages = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Operators", t => t.OperatorId, cascadeDelete: true)
                .Index(t => t.OperatorId);
            
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperatorId = c.Int(nullable: false),
                        Catagory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjectCode = c.String(),
                        Gpa = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniId = c.String(),
                        Name = c.String(),
                        Nickname = c.String(),
                        Password = c.String(),
                        SscRegistration = c.String(),
                        SscPassingYear = c.String(),
                        SscBoard = c.String(),
                        SscResult = c.Double(nullable: false),
                        HscRegistration = c.String(),
                        HscPassingYear = c.String(),
                        HscBoard = c.String(),
                        HscResult = c.Double(nullable: false),
                        FathersVoterId = c.Int(nullable: false),
                        FathersName = c.String(),
                        FathersDegignation = c.String(),
                        FathersContactNumber = c.String(),
                        FathersEmail = c.String(),
                        MothersVoterId = c.Int(nullable: false),
                        MothersName = c.String(),
                        MothersDegignation = c.String(),
                        MothersContactNumber = c.String(),
                        MothersEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TakeCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SemisterId = c.Int(nullable: false),
                        StudentId = c.String(),
                        CourseId = c.Int(nullable: false),
                        Section = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Semisters", t => t.SemisterId, cascadeDelete: true)
                .Index(t => t.SemisterId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TakeCourses", "SemisterId", "dbo.Semisters");
            DropForeignKey("dbo.TakeCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Messages", "OperatorId", "dbo.Operators");
            DropForeignKey("dbo.CourseAssigns", "WeekDaysId", "dbo.WeekDays");
            DropForeignKey("dbo.CourseAssigns", "TimeSlotId", "dbo.TimeSlots");
            DropForeignKey("dbo.CourseAssigns", "SemisterId", "dbo.Semisters");
            DropForeignKey("dbo.CourseAssigns", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.CourseAssigns", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.CourseAssigns", "CourseId", "dbo.Courses");
            DropIndex("dbo.TakeCourses", new[] { "CourseId" });
            DropIndex("dbo.TakeCourses", new[] { "SemisterId" });
            DropIndex("dbo.Messages", new[] { "OperatorId" });
            DropIndex("dbo.CourseAssigns", new[] { "FacultyId" });
            DropIndex("dbo.CourseAssigns", new[] { "RoomId" });
            DropIndex("dbo.CourseAssigns", new[] { "WeekDaysId" });
            DropIndex("dbo.CourseAssigns", new[] { "TimeSlotId" });
            DropIndex("dbo.CourseAssigns", new[] { "CourseId" });
            DropIndex("dbo.CourseAssigns", new[] { "SemisterId" });
            DropTable("dbo.TakeCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Results");
            DropTable("dbo.Operators");
            DropTable("dbo.Messages");
            DropTable("dbo.LogIns");
            DropTable("dbo.WeekDays");
            DropTable("dbo.TimeSlots");
            DropTable("dbo.Semisters");
            DropTable("dbo.Rooms");
            DropTable("dbo.Faculties");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseAssigns");
            DropTable("dbo.Admins");
            DropTable("dbo.AdminLogIns");
        }
    }
}
