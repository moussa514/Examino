namespace Examino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        AnswerLabel = c.String(nullable: false),
                        IsRightAnswer = c.Boolean(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        QuestionLabel = c.String(nullable: false),
                        Weight = c.Int(nullable: false),
                        QuestionType = c.Int(nullable: false),
                        SolutionDescription = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizzes", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quizzes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        Password = c.String(),
                        Duration = c.DateTime(nullable: false),
                        IsRandom = c.Boolean(nullable: false),
                        Description = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Group_Id = c.Int(),
                        Course_Id = c.Int(),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Group_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.School_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserQuizzes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        Group_Id = c.Int(),
                        Course_Id = c.Int(),
                        Quiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Quizzes", t => t.QuizId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Quizzes", t => t.Quiz_Id)
                .Index(t => t.QuizId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CourseId)
                .Index(t => t.GroupId)
                .Index(t => t.Group_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Quiz_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.CourseFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FileType = c.Int(nullable: false),
                        Link = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomGroupe = c.String(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.UserAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserQuizId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        IsUserAnswer = c.Boolean(nullable: false),
                        Development = c.String(),
                        Point = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.UserQuizzes", t => t.UserQuizId, cascadeDelete: true)
                .Index(t => t.UserQuizId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Code = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Photo = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.CourseFileCourses",
                c => new
                    {
                        CourseFile_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseFile_Id, t.Course_Id })
                .ForeignKey("dbo.CourseFiles", t => t.CourseFile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.CourseFile_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.UserDetails", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserDetails", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Schools", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserQuizzes", "Quiz_Id", "dbo.Quizzes");
            DropForeignKey("dbo.UserAnswers", "UserQuizId", "dbo.UserQuizzes");
            DropForeignKey("dbo.UserAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.UserQuizzes", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserQuizzes", "QuizId", "dbo.Quizzes");
            DropForeignKey("dbo.UserQuizzes", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserQuizzes", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AspNetUsers", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.UserQuizzes", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Quizzes", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Groups", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.AspNetUsers", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.UserQuizzes", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.CourseFileCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.CourseFileCourses", "CourseFile_Id", "dbo.CourseFiles");
            DropForeignKey("dbo.Quizzes", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizzes");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.CourseFileCourses", new[] { "Course_Id" });
            DropIndex("dbo.CourseFileCourses", new[] { "CourseFile_Id" });
            DropIndex("dbo.UserDetails", new[] { "SchoolId" });
            DropIndex("dbo.UserDetails", new[] { "ApplicationUserId" });
            DropIndex("dbo.Schools", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserAnswers", new[] { "QuestionId" });
            DropIndex("dbo.UserAnswers", new[] { "UserQuizId" });
            DropIndex("dbo.Groups", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserQuizzes", new[] { "Quiz_Id" });
            DropIndex("dbo.UserQuizzes", new[] { "Course_Id" });
            DropIndex("dbo.UserQuizzes", new[] { "Group_Id" });
            DropIndex("dbo.UserQuizzes", new[] { "GroupId" });
            DropIndex("dbo.UserQuizzes", new[] { "CourseId" });
            DropIndex("dbo.UserQuizzes", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserQuizzes", new[] { "QuizId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "School_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Course_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Group_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Quizzes", new[] { "Course_Id" });
            DropIndex("dbo.Quizzes", new[] { "ApplicationUserId" });
            DropIndex("dbo.Questions", new[] { "QuizId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.CourseFileCourses");
            DropTable("dbo.UserDetails");
            DropTable("dbo.Schools");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserAnswers");
            DropTable("dbo.Groups");
            DropTable("dbo.CourseFiles");
            DropTable("dbo.Courses");
            DropTable("dbo.UserQuizzes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Quizzes");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
