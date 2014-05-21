using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FundApp.Models
{
    public class FundContext : DbContext
    {
        public FundContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RankUser> RankUsers { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Ecologist> Ecologists { get; set; }

        public DbSet<Achievement> Achivements { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Council> Councils { get; set; }
        public DbSet<EcologicalProblem> EcologicalProblems { get; set; }
        public DbSet<OrganisationDeptor> OrganisationDeptors { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnershipRequest> PartnershipRequests { get; set; }
        public DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}