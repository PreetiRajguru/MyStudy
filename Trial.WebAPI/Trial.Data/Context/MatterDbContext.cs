using Microsoft.EntityFrameworkCore;
using Trial.Data.Models;

namespace Trial.Data.Context
{
    public class MatterDbContext : DbContext
    {
        public MatterDbContext()
        {

        }
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

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
                }



            //one to many
            modelBuilder.Entity<Client>()
                    .HasMany(e => e.Matters)
                    .WithOne(e => e.Client)
                    .HasForeignKey(e => e.ClientId)
                    .IsRequired();


            modelBuilder.Entity<Attorney>()
                  .HasMany(e => e.Roles)
                  .WithOne(e => e.Attorney)
                  .HasForeignKey(e => e.AttorneyId)
                  .IsRequired();

            modelBuilder.Entity<Attorney>()
                  .HasMany(e => e.Jurisdictions)
                  .WithOne(e => e.Attorney)
                  .HasForeignKey(e => e.AttorneyId)
                  .IsRequired();

            modelBuilder.Entity<Matter>()
                  .HasMany(e => e.Invoices)
                  .WithOne(e => e.Matter)
                  .HasForeignKey(e => e.MatterId)
                  .IsRequired();

            //one to one 
            modelBuilder.Entity<Matter>()
                    .HasOne(e => e.Attorney)
                    .WithOne(e => e.Matter)
                    .HasForeignKey<Attorney>(e => e.MatterId)
                    .IsRequired();

            modelBuilder.Entity<Attorney>()
                   .HasOne(e => e.Rate)
                   .WithOne(e => e.Attorney)
                   .HasForeignKey<Rate>(e => e.AttorneyId)
                   .IsRequired();

            modelBuilder.Entity<Matter>()
                  .HasOne(e => e.Jurisdiction)
                  .WithOne(e => e.Matter)
                  .HasForeignKey<Jurisdiction>(e => e.MatterId)
                  .IsRequired();


            //many to many
            modelBuilder.Entity<Attorney>()
                  .HasMany(e => e.Invoices)
                  .WithMany(e => e.Attorneys)
                  .UsingEntity<AttorneyInvoice>(
                                l => l.HasOne<Invoice>().WithMany().HasForeignKey(e => e.InvoiceId),
                                r => r.HasOne<Attorney>().WithMany().HasForeignKey(e => e.AttorneyId));
        }
    }
}
