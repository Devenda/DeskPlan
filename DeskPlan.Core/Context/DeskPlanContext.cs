using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DeskPlan.Core.Entities;

namespace DeskPlan.Core.Context
{
    public partial class DeskPlanContext : DbContext
    {
        public virtual DbSet<Desk> Desk { get; set; }
        public virtual DbSet<Planning> Planning { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<User> User { get; set; }

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
