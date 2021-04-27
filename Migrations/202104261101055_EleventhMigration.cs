namespace BBGCombination.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EleventhMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityLog_tbl", "FacilityType", c => c.String());
            AddColumn("dbo.ActivityLog_tbl", "AccountNumber", c => c.String());
            AddColumn("dbo.ActivityLog_tbl", "AccountName", c => c.String());
            AddColumn("dbo.ActivityLog_tbl", "OutstandingAmt", c => c.Double(nullable: false));
            AddColumn("dbo.ActivityLog_tbl", "DueAmount", c => c.Double(nullable: false));
            AddColumn("dbo.ActivityLog_tbl", "ExpiredDate", c => c.String());
            AddColumn("dbo.EmailNotify_tbl", "LoanDaysLeft", c => c.Int(nullable: false));
            AddColumn("dbo.EmailNotify_tbl", "FacilityType", c => c.String());
            AddColumn("dbo.EmailNotify_tbl", "AccountNumber", c => c.String());
            AddColumn("dbo.EmailNotify_tbl", "AccountName", c => c.String());
            AddColumn("dbo.EmailNotify_tbl", "OutstandingAmt", c => c.Double(nullable: false));
            AddColumn("dbo.EmailNotify_tbl", "DueAmount", c => c.Double(nullable: false));
            AddColumn("dbo.ErrorLog_tbl", "Exception", c => c.String());
            AddColumn("dbo.ErrorLog_tbl", "NoOfLoanDaysRemaining", c => c.String());
            AddColumn("dbo.ErrorLog_tbl", "FacilityType", c => c.String());
            AddColumn("dbo.ErrorLog_tbl", "AccountNumber", c => c.String());
            AddColumn("dbo.ErrorLog_tbl", "AccountName", c => c.String());
            AddColumn("dbo.ErrorLog_tbl", "OutstandingAmt", c => c.Double(nullable: false));
            AddColumn("dbo.ErrorLog_tbl", "ExpiredDate", c => c.String());
            AddColumn("dbo.ErrorLog_tbl", "DueAmount", c => c.Double(nullable: false));
            AddColumn("dbo.OverdraftLoan_tbl", "FacilityType", c => c.String());
            AddColumn("dbo.OverdraftLoan_tbl", "InterestOutstanding", c => c.Double(nullable: false));
            AddColumn("dbo.OverdraftLoan_tbl", "OutstandingAmt", c => c.Double(nullable: false));
            AddColumn("dbo.OverdraftLoan_tbl", "NextDemandDate", c => c.String());
            AddColumn("dbo.OverdraftLoan_tbl", "DueDate", c => c.String());
            AddColumn("dbo.OverdraftLoan_tbl", "PastDueObligationAmt", c => c.Double(nullable: false));
            AddColumn("dbo.OverdraftLoan_tbl", "DueAmt", c => c.Double(nullable: false));
            AddColumn("dbo.OverdraftLoan_tbl", "PrincipalOutstanding", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OverdraftLoan_tbl", "PrincipalOutstanding");
            DropColumn("dbo.OverdraftLoan_tbl", "DueAmt");
            DropColumn("dbo.OverdraftLoan_tbl", "PastDueObligationAmt");
            DropColumn("dbo.OverdraftLoan_tbl", "DueDate");
            DropColumn("dbo.OverdraftLoan_tbl", "NextDemandDate");
            DropColumn("dbo.OverdraftLoan_tbl", "OutstandingAmt");
            DropColumn("dbo.OverdraftLoan_tbl", "InterestOutstanding");
            DropColumn("dbo.OverdraftLoan_tbl", "FacilityType");
            DropColumn("dbo.ErrorLog_tbl", "DueAmount");
            DropColumn("dbo.ErrorLog_tbl", "ExpiredDate");
            DropColumn("dbo.ErrorLog_tbl", "OutstandingAmt");
            DropColumn("dbo.ErrorLog_tbl", "AccountName");
            DropColumn("dbo.ErrorLog_tbl", "AccountNumber");
            DropColumn("dbo.ErrorLog_tbl", "FacilityType");
            DropColumn("dbo.ErrorLog_tbl", "NoOfLoanDaysRemaining");
            DropColumn("dbo.ErrorLog_tbl", "Exception");
            DropColumn("dbo.EmailNotify_tbl", "DueAmount");
            DropColumn("dbo.EmailNotify_tbl", "OutstandingAmt");
            DropColumn("dbo.EmailNotify_tbl", "AccountName");
            DropColumn("dbo.EmailNotify_tbl", "AccountNumber");
            DropColumn("dbo.EmailNotify_tbl", "FacilityType");
            DropColumn("dbo.EmailNotify_tbl", "LoanDaysLeft");
            DropColumn("dbo.ActivityLog_tbl", "ExpiredDate");
            DropColumn("dbo.ActivityLog_tbl", "DueAmount");
            DropColumn("dbo.ActivityLog_tbl", "OutstandingAmt");
            DropColumn("dbo.ActivityLog_tbl", "AccountName");
            DropColumn("dbo.ActivityLog_tbl", "AccountNumber");
            DropColumn("dbo.ActivityLog_tbl", "FacilityType");
        }
    }
}
