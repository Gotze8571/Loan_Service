namespace BBGCombination.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NinthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TermLoan_tbl", "AccountName", c => c.String());
            AlterColumn("dbo.TermLoan_tbl", "AccountNumber", c => c.String());
            AlterColumn("dbo.TermLoan_tbl", "DueDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TermLoan_tbl", "DueDate", c => c.String(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "AccountNumber", c => c.String(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "AccountName", c => c.String(nullable: false));
        }
    }
}
