namespace BBGCombination.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityLog_tbl", "LoanDaysLeft", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActivityLog_tbl", "LoanDaysLeft");
        }
    }
}
