using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DeskPlan.Core.Entities;

namespace DeskPlan.Core.Context
{
    public partial class DeskPlanContext : DbContext
    {
        public DbSet<Desk> Desk => Set<Desk>();
        public DbSet<Planning> Planning => Set<Planning>();
        public DbSet<Room> Room => Set<Room>();
        public DbSet<User> User => Set<User>();

        public DeskPlanContext()
        {
        }

        public DeskPlanContext(DbContextOptions<DeskPlanContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=DeskPlan.sqlite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Number)
                        .IsUnique();
        }
    }
}
