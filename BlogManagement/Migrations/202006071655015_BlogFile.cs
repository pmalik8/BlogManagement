namespace BlogManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "FileName");
        }
    }
}
