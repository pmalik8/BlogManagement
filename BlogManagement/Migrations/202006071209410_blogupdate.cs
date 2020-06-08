namespace BlogManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Header", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Header");
        }
    }
}
