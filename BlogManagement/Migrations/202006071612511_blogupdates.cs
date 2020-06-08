namespace BlogManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogupdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Blogs", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Blogs", "ApplicationUserId");
            AddForeignKey("dbo.Blogs", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Blogs", new[] { "ApplicationUserId" });
            DropColumn("dbo.Blogs", "ApplicationUserId");
            DropColumn("dbo.Blogs", "CreateDate");
        }
    }
}
