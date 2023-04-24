using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Data.Models;

namespace Trial.Data.Context
{
    public class MatterDbContext : DbContext
    {
        public MatterDbContext(DbContextOptions<MatterDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Matter> Matters { get; set; }
        public DbSet<Attorney> Attorneys { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Jurisdiction> Jurisdictions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<AttorneyInvoice> AttorneyInvoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=MattersTrial;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //primary keys

            modelBuilder.Entity<Client>()
            .HasKey(b => b.Id)
                .HasName("PrimaryKey_ClientId");

            modelBuilder.Entity<Matter>()
                .HasKey(b => b.Id)
                .HasName("PrimaryKey_MatterId");

            modelBuilder.Entity<Attorney>()
            .HasKey(b => b.Id)
               .HasName("PrimaryKey_AttorneyId");

            modelBuilder.Entity<Role>()
               .HasKey(b => b.Id)
               .HasName("PrimaryKey_RoleId");

            modelBuilder.Entity<Rate>()
               .HasKey(b => b.Id)
               .HasName("PrimaryKey_RateId");

            modelBuilder.Entity<Jurisdiction>()
               .HasKey(b => b.Id)
               .HasName("PrimaryKey_JurisdictionId");

            modelBuilder.Entity<Invoice>()
               .HasKey(b => b.Id)
               .HasName("PrimaryKey_InvoiceId");


            //one to one
            modelBuilder.Entity<Rate>()
            .HasOne(e => e.Invoice)
            .WithOne(ed => ed.Rate)
            .HasForeignKey<Invoice>(ed => ed.RateId);


            modelBuilder.Entity<Rate>()
            .HasOne(e => e.Attorney)
            .WithOne(ed => ed.Rate)
            .HasForeignKey<Attorney>(ed => ed.RateId);


            //many to one 

            modelBuilder.Entity<Matter>()
              .HasOne<Attorney>(o => o.BillingAttorney)
              .WithMany(c => c.Matters)
              .HasForeignKey(o => o.BillingAttorneyId);

            modelBuilder.Entity<Matter>()
              .HasOne<Attorney>(o => o.ResponsibleAttorney)
              .WithMany(c => c.Matters)
              .HasForeignKey(o => o.ResponsibleAttorneyId);

            modelBuilder.Entity<Matter>()
             .HasOne<Jurisdiction>(o => o.Jurisdiction)
             .WithMany(c => c.Matters)
             .HasForeignKey(o => o.JuridictionId);

            //one to many

            modelBuilder.Entity<Matter>()
            .HasOne(b => b.Client)
            .WithMany(a => a.Matters)
            .HasForeignKey(b => b.ClientId);


            modelBuilder.Entity<Jurisdiction>()
            .HasOne(b => b.Attorney)
            .WithMany(a => a.Jurisdictions)
            .HasForeignKey(b => b.AttorneyId);


            modelBuilder.Entity<Invoice>()
            .HasOne(b => b.Matter)
            .WithMany(a => a.Invoices)
            .HasForeignKey(b => b.MatterId);

            modelBuilder.Entity<Role>()
            .HasOne(b => b.Attorney)
            .WithMany(a => a.Roles)
            .HasForeignKey(b => b.AttorneyId);


            //many to many

            modelBuilder.Entity<AttorneyInvoice>()
                .HasKey(ai => new { ai.AttorneyId, ai.InvoiceId });

            modelBuilder.Entity<AttorneyInvoice>()
                .HasOne(ai => ai.Attorney)
                .WithMany(a => a.AttorneyInvoices)
                .HasForeignKey(ai => ai.AttorneyId);

            modelBuilder.Entity<AttorneyInvoice>()
                .HasOne(ai => ai.Invoice)
                .WithMany(i => i.AttorneyInvoices)
                .HasForeignKey(ai => ai.InvoiceId);
        }
    }
}
