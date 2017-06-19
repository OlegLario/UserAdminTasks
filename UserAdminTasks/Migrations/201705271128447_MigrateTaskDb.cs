namespace UserAdminTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateTaskDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArchiveTask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDateTask = c.DateTime(nullable: false),
                        Description = c.String(),
                        PlannedStartDate = c.DateTime(nullable: false),
                        PlannedCompletionDate = c.DateTime(nullable: false),
                        StartExecution = c.Boolean(nullable: false),
                        IsExecution = c.Boolean(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        FromUserId = c.Int(),
                        ToUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FromUserId)
                .ForeignKey("dbo.Users", t => t.ToUserId)
                .Index(t => t.FromUserId)
                .Index(t => t.ToUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDateTask = c.DateTime(nullable: false),
                        Description = c.String(),
                        PlannedStartDate = c.DateTime(nullable: false),
                        PlannedCompletionDate = c.DateTime(nullable: false),
                        StartExecution = c.Boolean(nullable: false),
                        IsExecution = c.Boolean(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        FromUserId = c.Int(),
                        ToUserId = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FromUserId)
                .ForeignKey("dbo.Users", t => t.ToUserId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.FromUserId)
                .Index(t => t.ToUserId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArchiveTasks", "ToUserId", "dbo.Users");
            DropForeignKey("dbo.ArchiveTasks", "FromUserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Tasks", "ToUserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "FromUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Tasks", new[] { "User_Id" });
            DropIndex("dbo.Tasks", new[] { "ToUserId" });
            DropIndex("dbo.Tasks", new[] { "FromUserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.ArchiveTasks", new[] { "ToUserId" });
            DropIndex("dbo.ArchiveTasks", new[] { "FromUserId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.ArchiveTasks");
        }
    }
}
