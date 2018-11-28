using Microsoft.AspNet.Identity.EntityFramework;
using Nixi.Areas.Admin.Models;
using Nixi.Areas.Diary.Models;
using Nixi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Nixi.DAL
{
    public class NixiContext : IdentityDbContext<ApplicationUser>
    {
        public NixiContext() : base("NixiContext", throwIfV1Schema: false)
        {
        }

        public static NixiContext Create()
        {
            return new NixiContext();
        }

        // Admin Models
        public DbSet<Toddler> Toddlers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CMFile> CMFiles { get; set; }
        public DbSet<ContactAssociation> ContactAssociations { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<AgreedPeriod> AgreedPeriods { get; set; }
        public DbSet<AgreedDay> AgreedDays { get; set; }

        public DbSet<Settings> Settings { get; set; }
        public DbSet<ClosingDay> ClosingDays { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        
        // Diary Models
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Toddler>()
                .HasOptional(t => t.CMFile)
                .WithRequired(s => s.Toddler);
            //modelBuilder.Entity<Toddler>()
            //    .HasMany(t => t.Parents).WithMany(p => p.Children)
            //    .Map(t => t.MapLeftKey("ToddlerId").MapRightKey("PersonId")
            //    .ToTable("_ToddlerParent"));
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Classes).WithMany(p => p.Responsibles);
            //modelBuilder.Entity<Toddler>()
            //    .HasMany(t => t.Siblings).WithMany()
            //    .Map(t => t.MapLeftKey("ToddlerId").MapRightKey("SiblingId").ToTable("Siblings"));
            modelBuilder.Entity<Toddler>()
                .HasMany(t => t.Pickups).WithMany();
                
        }

        
    }
}