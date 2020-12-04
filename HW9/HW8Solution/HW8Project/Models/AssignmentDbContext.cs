using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HW8Project.Models
{
    public partial class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext()
        {
        }

        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AssignmentTag> AssignmentTags { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.IsComplete).HasDefaultValueSql("('FALSE')");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Assignment_FK_Class");
            });

            modelBuilder.Entity<AssignmentTag>(entity =>
            {
                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.AssignmentTags)
                    .HasForeignKey(d => d.AssignmentId)
                    .HasConstraintName("AssignmentTags_FK_Assignment");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.AssignmentTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("AssignmentTags_FK_Tags");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
