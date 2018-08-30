using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BluwaterCrmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BluwaterCrmApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
                .Property(c => c.CreatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Customer>()
                .Property(c => c.UpdatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.CustomerGuid);
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Organization)
                .WithMany(c => c.Customers)
                .IsRequired(false);

            modelBuilder.Entity<Organization>()
                .Property(o => o.CreatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Organization>()
                .Property(o => o.UpdatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Organization>()
                .HasIndex(o => o.OrganizationGuid);

            modelBuilder.Entity<Interaction>()
                .Property(i => i.CreatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Interaction>()
                .Property(i => i.UpdatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Interaction>()
                .HasIndex(i => i.InteractionGuid);

            modelBuilder.Entity<Note>()
                .Property(n => n.CreatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Note>()
                .Property(n => n.UpdatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Note>()
                .HasIndex(n => n.NoteGuid);

            modelBuilder.Entity<Deal>()
                .Property(d => d.CreatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Deal>()
                .Property(d => d.UpdatedTimestamp)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Deal>()
                .HasIndex(d => d.DealGuid);
            modelBuilder.Entity<Deal>()
                .HasOne(d => d.Customer)
                .WithMany(d => d.Deals)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<IndustryTag>()
                .Property(i => i.CreatedTimestamp)
                .HasDefaultValueSql("getdate()");

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<IndustryTag> IndustryTags { get; set; }
    }
}
