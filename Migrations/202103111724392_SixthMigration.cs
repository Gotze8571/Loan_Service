namespace BBGCombination.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityLog_tbl", "EmailRecipient", c => c.String());
            AddColumn("dbo.EmailNotify_tbl", "EmailRecipient", c => c.String());
            AddColumn("dbo.ErrorLog_tbl", "EmailRecipient", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ErrorLog_tbl", "EmailRecipient");
            DropColumn("dbo.EmailNotify_tbl", "EmailRecipient");
            DropColumn("dbo.ActivityLog_tbl", "EmailRecipient");
        }
    }
}
