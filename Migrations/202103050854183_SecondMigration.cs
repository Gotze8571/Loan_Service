namespace BBGCombination.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerDetails_tbl", "DueAmt", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerDetails_tbl", "DueAmt", c => c.String());
        }
    }
}
