namespace BBGCombination.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeventhMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailNotify_tbl", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailNotify_tbl", "Status");
        }
    }
}
