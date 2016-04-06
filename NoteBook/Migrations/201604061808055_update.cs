namespace NoteBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CityId = c.Int(nullable: false),
                        Address = c.String(),
                        ContactName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Skype = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        PositionId = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Skype = c.String(),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.PositionId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CityId = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Skype = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            AddColumn("dbo.AspNetUsers", "ProfileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Stores", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Profiles", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Companies", "CityId", "dbo.Cities");
            DropIndex("dbo.Stores", new[] { "CityId" });
            DropIndex("dbo.Profiles", new[] { "StoreId" });
            DropIndex("dbo.Profiles", new[] { "PositionId" });
            DropIndex("dbo.Companies", new[] { "CityId" });
            DropColumn("dbo.AspNetUsers", "ProfileId");
            DropTable("dbo.Stores");
            DropTable("dbo.Profiles");
            DropTable("dbo.Positions");
            DropTable("dbo.Companies");
            DropTable("dbo.Cities");
        }
    }
}
