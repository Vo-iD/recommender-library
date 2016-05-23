namespace RL.OwnData.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        Description = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        Date = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        Receiver_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Receiver_Id)
                .ForeignKey("dbo.Users", t => t.Sender_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionnaireAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionnaireItems", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.QuestionnaireItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                        Questionnaire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questionnaires", t => t.Questionnaire_Id)
                .Index(t => t.Questionnaire_Id);
            
            CreateTable(
                "dbo.Questionnaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Notes = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionnaireHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PassDate = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        Questionnaire_Id = c.Int(),
                        Respondent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questionnaires", t => t.Questionnaire_Id)
                .ForeignKey("dbo.Users", t => t.Respondent_Id)
                .Index(t => t.Questionnaire_Id)
                .Index(t => t.Respondent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionnaireHistories", "Respondent_Id", "dbo.Users");
            DropForeignKey("dbo.QuestionnaireHistories", "Questionnaire_Id", "dbo.Questionnaires");
            DropForeignKey("dbo.QuestionnaireAnswers", "Question_Id", "dbo.QuestionnaireItems");
            DropForeignKey("dbo.QuestionnaireItems", "Questionnaire_Id", "dbo.Questionnaires");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users");
            DropIndex("dbo.QuestionnaireHistories", new[] { "Respondent_Id" });
            DropIndex("dbo.QuestionnaireHistories", new[] { "Questionnaire_Id" });
            DropIndex("dbo.QuestionnaireItems", new[] { "Questionnaire_Id" });
            DropIndex("dbo.QuestionnaireAnswers", new[] { "Question_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropTable("dbo.QuestionnaireHistories");
            DropTable("dbo.Questionnaires");
            DropTable("dbo.QuestionnaireItems");
            DropTable("dbo.QuestionnaireAnswers");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Marks");
        }
    }
}
