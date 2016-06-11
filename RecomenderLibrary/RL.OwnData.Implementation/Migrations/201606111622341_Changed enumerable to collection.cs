namespace RL.OwnData.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedenumerabletocollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "User_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.QuestionnaireItems", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.QuestionnaireItems", "User_Id");
            CreateIndex("dbo.Messages", "User_Id");
            CreateIndex("dbo.Messages", "User_Id1");
            AddForeignKey("dbo.QuestionnaireItems", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "User_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "User_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuestionnaireItems", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "User_Id1" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.QuestionnaireItems", new[] { "User_Id" });
            DropColumn("dbo.QuestionnaireItems", "User_Id");
            DropColumn("dbo.Messages", "User_Id1");
            DropColumn("dbo.Messages", "User_Id");
        }
    }
}
