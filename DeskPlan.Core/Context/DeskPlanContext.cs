using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DeskPlan.Core.Entities;

namespace DeskPlan.Core.Context
{
    public partial class DeskPlanContext : DbContext
    {
        public DeskPlanContext()
        {
        }

        public DeskPlanContext(DbContextOptions<DeskPlanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desk> Desk { get; set; }
        public virtual DbSet<Planning> Planning { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("name=DeskPlanDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desk>(entity =>
            {
                entity.Property(e => e.DeskId).ValueGeneratedNever();

                entity.Property(e => e.Flex)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LocationX).HasColumnType("int");

                entity.Property(e => e.LocationY).HasColumnType("int");

                entity.Property(e => e.Name).HasColumnType("nvarchar(50)");

                entity.Property(e => e.RoomId).HasColumnType("int");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Desk)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Planning>(entity =>
            {
                entity.Property(e => e.PlanningId).ValueGeneratedNever();

                entity.Property(e => e.DeskId).HasColumnType("int");

                entity.Property(e => e.UserId).HasColumnType("int");

                entity.Property(e => e.Week).HasColumnType("tinyint");

                entity.Property(e => e.Year).HasColumnType("smallint");

                entity.HasOne(d => d.Desk)
                    .WithMany(p => p.Planning)
                    .HasForeignKey(d => d.DeskId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Planning)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).ValueGeneratedNever();

                entity.Property(e => e.Desks).HasColumnType("tinyint");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar(100)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.EmailAddress).HasColumnType("nvarchar(50)");

                entity.Property(e => e.EndDate).HasColumnType("nvarchar(50)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.Number).HasColumnType("int");

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
