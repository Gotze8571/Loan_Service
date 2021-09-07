namespace BBGCombination.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TermLoan_tbl", "FacilityType", c => c.String());
            AddColumn("dbo.TermLoan_tbl", "InterestOutstanding", c => c.Double(nullable: false));
            AddColumn("dbo.TermLoan_tbl", "OutstandingAmt", c => c.Double(nullable: false));
            AddColumn("dbo.TermLoan_tbl", "NextDemandDate", c => c.String());
            AddColumn("dbo.TermLoan_tbl", "OutstandingRepayment", c => c.Double(nullable: false));
            AddColumn("dbo.TermLoan_tbl", "AccountBalance", c => c.Double(nullable: false));
            AddColumn("dbo.TermLoan_tbl", "CustomerEmail", c => c.String());
            AlterColumn("dbo.TermLoan_tbl", "PastDueObligationAmt", c => c.Double(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "CurrentOutstandingAmt", c => c.Double(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "DueAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "DueDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TermLoan_tbl", "DueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "DueAmount", c => c.String(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "CurrentOutstandingAmt", c => c.String(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "PastDueObligationAmt", c => c.String(nullable: false));
            DropColumn("dbo.TermLoan_tbl", "CustomerEmail");
            DropColumn("dbo.TermLoan_tbl", "AccountBalance");
            DropColumn("dbo.TermLoan_tbl", "OutstandingRepayment");
            DropColumn("dbo.TermLoan_tbl", "NextDemandDate");
            DropColumn("dbo.TermLoan_tbl", "OutstandingAmt");
            DropColumn("dbo.TermLoan_tbl", "InterestOutstanding");
            DropColumn("dbo.TermLoan_tbl", "FacilityType");
        }
    }
}
