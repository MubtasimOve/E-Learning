namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.String(),
                        TId = c.Int(nullable: false),
                        LId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TId, cascadeDelete: true)
                .Index(t => t.TId)
                .Index(t => t.LId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fname = c.String(),
                        lname = c.String(),
                        phone = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fname = c.String(),
                        lname = c.String(),
                        email = c.String(),
                        age = c.String(),
                        PId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parents", t => t.PId, cascadeDelete: true)
                .Index(t => t.PId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "PId", "dbo.Parents");
            DropForeignKey("dbo.Courses", "TId", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "LId", "dbo.Lessons");
            DropIndex("dbo.Students", new[] { "PId" });
            DropIndex("dbo.Courses", new[] { "LId" });
            DropIndex("dbo.Courses", new[] { "TId" });
            DropTable("dbo.Students");
            DropTable("dbo.Parents");
            DropTable("dbo.Notices");
            DropTable("dbo.Teachers");
            DropTable("dbo.Lessons");
            DropTable("dbo.Courses");
        }
    }
}
