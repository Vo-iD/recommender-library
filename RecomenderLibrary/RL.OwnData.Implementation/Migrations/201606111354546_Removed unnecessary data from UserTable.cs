namespace RL.OwnData.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedunnecessarydatafromUserTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "RegisterDate");
            DropColumn("dbo.AspNetUsers", "LastLoginDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LastLoginDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "RegisterDate", c => c.DateTime(nullable: false));
        }
    }
}
