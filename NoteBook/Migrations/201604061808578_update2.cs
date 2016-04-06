namespace NoteBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AspNetUsers", "ProfileId");
            AddForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "ProfileId" });
        }
    }
}
