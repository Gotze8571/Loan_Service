namespace BBGCombination.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerDetails_tbl", "FacilityType", c => c.String());
            AddColumn("dbo.CustomerDetails_tbl", "NextDemandDate", c => c.String());
            AddColumn("dbo.CustomerDetails_tbl", "PrincipalOutstanding", c => c.Double(nullable: false));
            AddColumn("dbo.CustomerDetails_tbl", "InterestOutstanding", c => c.Double(nullable: false));
            AddColumn("dbo.CustomerDetails_tbl", "OutstandingRepayment", c => c.Double(nullable: false));
            AddColumn("dbo.CustomerDetails_tbl", "AccountBalance", c => c.Double(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "AccountName", c => c.String(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "AccountNumber", c => c.String(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "PastDueObligationAmt", c => c.String(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "CurrentOutstandingAmt", c => c.String(nullable: false));
            AlterColumn("dbo.TermLoan_tbl", "DueAmount", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TermLoan_tbl", "DueAmount", c => c.String());
            AlterColumn("dbo.TermLoan_tbl", "CurrentOutstandingAmt", c => c.String());
            AlterColumn("dbo.TermLoan_tbl", "PastDueObligationAmt", c => c.String());
            AlterColumn("dbo.TermLoan_tbl", "AccountNumber", c => c.String());
            AlterColumn("dbo.TermLoan_tbl", "AccountName", c => c.String());
            DropColumn("dbo.CustomerDetails_tbl", "AccountBalance");
            DropColumn("dbo.CustomerDetails_tbl", "OutstandingRepayment");
            DropColumn("dbo.CustomerDetails_tbl", "InterestOutstanding");
            DropColumn("dbo.CustomerDetails_tbl", "PrincipalOutstanding");
            DropColumn("dbo.CustomerDetails_tbl", "NextDemandDate");
            DropColumn("dbo.CustomerDetails_tbl", "FacilityType");
        }
    }
}
