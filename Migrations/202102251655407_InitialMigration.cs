namespace BBGCombination.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityLog_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Activity = c.String(),
                        ActivityDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerDetails_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountNumber = c.String(),
                        DueAmt = c.String(),
                        DueDate = c.String(),
                        DueInDays = c.String(),
                        OutStandingAmt = c.Double(nullable: false),
                        PastDueObligationAmt = c.Double(nullable: false),
                        CustomerEmail = c.String(),
                        ExcessAmt = c.String(),
                        AgreeMonthlyVol = c.String(),
                        Email_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailNotify_tbl", t => t.Email_Id)
                .Index(t => t.Email_Id);
            
            CreateTable(
                "dbo.EmailNotify_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        EmailSent = c.Boolean(nullable: false),
                        EmailReceived = c.Boolean(nullable: false),
                        EmailDateSent = c.DateTime(nullable: false),
                        EmailDateReceived = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorLog_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ErrorName = c.String(nullable: false),
                        ErrorDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaseFinanceLoan_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountNumber = c.String(),
                        PastDueObligationAmt = c.String(),
                        CurrentOutstandingAmt = c.String(),
                        DueAmount = c.String(),
                        DueDate = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OverdraftLoan_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountNumber = c.String(),
                        ExpiryDate = c.String(),
                        CurrentOustandingBal = c.String(),
                        ExcessAmt = c.Double(nullable: false),
                        AgreeMonthVol = c.Double(nullable: false),
                        ShortFall = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TermLoan_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountNumber = c.String(),
                        PastDueObligationAmt = c.String(),
                        CurrentOutstandingAmt = c.String(),
                        DueAmount = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerDetails_tbl", "Email_Id", "dbo.EmailNotify_tbl");
            DropIndex("dbo.CustomerDetails_tbl", new[] { "Email_Id" });
            DropTable("dbo.TermLoan_tbl");
            DropTable("dbo.OverdraftLoan_tbl");
            DropTable("dbo.LeaseFinanceLoan_tbl");
            DropTable("dbo.ErrorLog_tbl");
            DropTable("dbo.EmailNotify_tbl");
            DropTable("dbo.CustomerDetails_tbl");
            DropTable("dbo.ActivityLog_tbl");
        }
    }
}
