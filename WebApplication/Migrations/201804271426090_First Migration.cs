namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentOnTheVisits",
                c => new
                    {
                        CommentOnTheVisitID = c.Int(nullable: false, identity: true),
                        TypeOfComment = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.CommentOnTheVisitID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 100),
                        Secondname = c.String(nullable: false, maxLength: 100),
                        Lastname = c.String(nullable: false, maxLength: 100),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Position = c.String(),
                        Specialty = c.String(),
                        Education = c.String(),
                        Comment = c.String(),
                        Degree = c.String(),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        ContactID = c.Int(nullable: false),
                        PatientStatus = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                        ImageID = c.Int(nullable: false),
                        DateTimeNextVisit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PatientID)
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: false)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: false)
                .Index(t => t.ContactID)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Title = c.String(),
                        ImageContent = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Researches",
                c => new
                    {
                        ResearchID = c.Int(nullable: false, identity: true),
                        ResearchType = c.Int(nullable: false),
                        StateOfTheResearch = c.Int(nullable: false),
                        Thumbnail = c.Binary(nullable: false),
                        ImageID = c.Int(nullable: false),
                        HairID = c.Int(nullable: false),
                        ResearchArea = c.Int(nullable: false),
                        Comment = c.String(),
                        ResearchTime = c.DateTime(nullable: false),
                        DiagnosticID = c.Int(nullable: false),
                        Treatment = c.String(),
                        SettingID = c.Int(nullable: false),
                        LensID = c.Int(nullable: false),
                        Setting_SettingsID = c.Int(),
                    })
                .PrimaryKey(t => t.ResearchID)
                .ForeignKey("dbo.Diagnostics", t => t.DiagnosticID, cascadeDelete: false)
                .ForeignKey("dbo.Settings", t => t.Setting_SettingsID)
                .ForeignKey("dbo.Hair", t => t.HairID, cascadeDelete: false)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: false)
                .ForeignKey("dbo.Lenses", t => t.LensID, cascadeDelete: false)
                .Index(t => t.ImageID)
                .Index(t => t.HairID)
                .Index(t => t.DiagnosticID)
                .Index(t => t.LensID)
                .Index(t => t.Setting_SettingsID);
            
            CreateTable(
                "dbo.Diagnostics",
                c => new
                    {
                        DiagnosticID = c.Int(nullable: false, identity: true),
                        DiagnosticText = c.String(nullable: false, maxLength: 2000),
                        CreationDate = c.DateTime(nullable: false),
                        DateOfLastConfirmation = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.DiagnosticID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.Binary(nullable: false),
                        LastLoginTime = c.DateTime(nullable: false),
                        LensID = c.Int(nullable: false),
                        DiagnosticID = c.Int(nullable: false),
                        SettingID = c.Int(nullable: false),
                        ContactID = c.Int(nullable: false),
                        Setting_SettingsID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: false)
                .ForeignKey("dbo.Diagnostics", t => t.DiagnosticID, cascadeDelete: false)
                .ForeignKey("dbo.Settings", t => t.Setting_SettingsID)
                .Index(t => t.DiagnosticID)
                .Index(t => t.ContactID)
                .Index(t => t.Setting_SettingsID);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingsID = c.Int(nullable: false, identity: true),
                        HairSizeSettingsID = c.Int(nullable: false),
                        StatisticalSettingsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SettingsID)
                .ForeignKey("dbo.HairSizeSettings", t => t.HairSizeSettingsID, cascadeDelete: false)
                .ForeignKey("dbo.StatisticalSettings", t => t.StatisticalSettingsID, cascadeDelete: false)
                .Index(t => t.HairSizeSettingsID)
                .Index(t => t.StatisticalSettingsID);
            
            CreateTable(
                "dbo.HairSizeSettings",
                c => new
                    {
                        HairSizeSettingsID = c.Int(nullable: false, identity: true),
                        LengthOfTelogenHair = c.Int(nullable: false),
                        DiameterOfVelusTerminal = c.Int(nullable: false),
                        DiameterOfTerminalsThinMedium = c.Int(nullable: false),
                        DiameterOfTerminalsMediumThick = c.Int(nullable: false),
                        RadiusOfFollicularUnits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HairSizeSettingsID);
            
            CreateTable(
                "dbo.StatisticalSettings",
                c => new
                    {
                        StatisticalSettingsID = c.Int(nullable: false, identity: true),
                        AnagenAll = c.Int(nullable: false),
                        TelogenAll = c.Int(nullable: false),
                        AnagenTerm = c.Int(nullable: false),
                        TelogenTerm = c.Int(nullable: false),
                        AnagenVallus = c.Int(nullable: false),
                        TelogenVallus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatisticalSettingsID);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Comment = c.String(),
                        ResearchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitID)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: false)
                .ForeignKey("dbo.Researches", t => t.ResearchID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PatientID)
                .Index(t => t.ResearchID);
            
            CreateTable(
                "dbo.Hair",
                c => new
                    {
                        HairID = c.Int(nullable: false, identity: true),
                        Width = c.Int(nullable: false),
                        X1 = c.Int(nullable: false),
                        X2 = c.Int(nullable: false),
                        Y1 = c.Int(nullable: false),
                        Y2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HairID);
            
            CreateTable(
                "dbo.Lenses",
                c => new
                    {
                        LensID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Scale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LensID);
            
            CreateTable(
                "dbo.FieldOptions",
                c => new
                    {
                        FieldOptionID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Selected = c.Boolean(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.FieldOptionID);
            
            CreateTable(
                "dbo.ReportFields",
                c => new
                    {
                        ReportFieldID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FieldType = c.Int(nullable: false),
                        FieldOptionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportFieldID)
                .ForeignKey("dbo.FieldOptions", t => t.FieldOptionID, cascadeDelete: false)
                .Index(t => t.FieldOptionID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureID = c.Int(nullable: false, identity: true),
                        Selected = c.Boolean(nullable: false),
                        Title = c.String(nullable: false),
                        Data = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.PictureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportFields", "FieldOptionID", "dbo.FieldOptions");
            DropForeignKey("dbo.Researches", "LensID", "dbo.Lenses");
            DropForeignKey("dbo.Researches", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Researches", "HairID", "dbo.Hair");
            DropForeignKey("dbo.Visits", "UserID", "dbo.Users");
            DropForeignKey("dbo.Visits", "ResearchID", "dbo.Researches");
            DropForeignKey("dbo.Visits", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Users", "Setting_SettingsID", "dbo.Settings");
            DropForeignKey("dbo.Settings", "StatisticalSettingsID", "dbo.StatisticalSettings");
            DropForeignKey("dbo.Researches", "Setting_SettingsID", "dbo.Settings");
            DropForeignKey("dbo.Settings", "HairSizeSettingsID", "dbo.HairSizeSettings");
            DropForeignKey("dbo.Users", "DiagnosticID", "dbo.Diagnostics");
            DropForeignKey("dbo.Users", "ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Researches", "DiagnosticID", "dbo.Diagnostics");
            DropForeignKey("dbo.Patients", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Patients", "ContactID", "dbo.Contacts");
            DropIndex("dbo.ReportFields", new[] { "FieldOptionID" });
            DropIndex("dbo.Visits", new[] { "ResearchID" });
            DropIndex("dbo.Visits", new[] { "PatientID" });
            DropIndex("dbo.Visits", new[] { "UserID" });
            DropIndex("dbo.Settings", new[] { "StatisticalSettingsID" });
            DropIndex("dbo.Settings", new[] { "HairSizeSettingsID" });
            DropIndex("dbo.Users", new[] { "Setting_SettingsID" });
            DropIndex("dbo.Users", new[] { "ContactID" });
            DropIndex("dbo.Users", new[] { "DiagnosticID" });
            DropIndex("dbo.Researches", new[] { "Setting_SettingsID" });
            DropIndex("dbo.Researches", new[] { "LensID" });
            DropIndex("dbo.Researches", new[] { "DiagnosticID" });
            DropIndex("dbo.Researches", new[] { "HairID" });
            DropIndex("dbo.Researches", new[] { "ImageID" });
            DropIndex("dbo.Patients", new[] { "ImageID" });
            DropIndex("dbo.Patients", new[] { "ContactID" });
            DropTable("dbo.Pictures");
            DropTable("dbo.ReportFields");
            DropTable("dbo.FieldOptions");
            DropTable("dbo.Lenses");
            DropTable("dbo.Hair");
            DropTable("dbo.Visits");
            DropTable("dbo.StatisticalSettings");
            DropTable("dbo.HairSizeSettings");
            DropTable("dbo.Settings");
            DropTable("dbo.Users");
            DropTable("dbo.Diagnostics");
            DropTable("dbo.Researches");
            DropTable("dbo.Images");
            DropTable("dbo.Patients");
            DropTable("dbo.Contacts");
            DropTable("dbo.CommentOnTheVisits");
        }
    }
}
