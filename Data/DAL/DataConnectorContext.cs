﻿using BBGCombination.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBGCombination.Domain.Data.DAL
{
    public class DataConnectorContext : System.Data.Entity.DbContext
    {
        public DataConnectorContext() : base("BBGLoanCombinationContext")
        {
        }
        public DbSet<ActivityLog> Activitylogs { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<EmailNotify> EmailNotifies { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<TermLoan> TermLoans { get; set; }
        public DbSet<LeaseFinanceLoan> LeaseFinances { get; set; }
        public DbSet<OverdraftLoan> OverdraftLoans { get; set; }
        public static DataConnectorContext Create()
        {
            return new DataConnectorContext();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
