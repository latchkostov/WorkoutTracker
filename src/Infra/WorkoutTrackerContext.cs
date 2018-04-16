using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Models;

namespace WorkoutTracker.Infra
{
    public class WorkoutTrackerContext : DbContext
    {
        public WorkoutTrackerContext(DbContextOptions<WorkoutTrackerContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        public DbSet<ExerciseMuscleGroupJoin> ExerciseMuscleGroupsJoins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.Name).IsRequired();
                e.HasIndex(p => p.Name).IsUnique();
                e.Property(p => p.Description);
                e.Property(p => p.VideoLink);

                e.Ignore(p => p.MuscleGroups);
            });

            modelBuilder.Entity<MuscleGroup>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Id).ValueGeneratedOnAdd();
                m.Property(p => p.Name).IsRequired();
                m.HasIndex(p => p.Name).IsUnique();

                m.Ignore(p => p.Exercises);
            });

            modelBuilder.Entity<ExerciseMuscleGroupJoin>(em =>
            {
                em.ToTable("Exercise_MuscleGroup");
                em.HasKey(p => new { p.ExerciseId, p.MuscleGroupId });
                em.HasOne(p => p.Exercise)
                    .WithMany(p => p.ExerciseMuscleGroups)
                    .HasForeignKey(p => p.ExerciseId);
                em.HasOne(p => p.MuscleGroup)
                    .WithMany(p => p.ExerciseMuscleGroups)
                    .HasForeignKey(p => p.MuscleGroupId);
            });
        }
    }
}
