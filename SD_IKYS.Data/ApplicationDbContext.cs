using Microsoft.EntityFrameworkCore;
using SD_IKYS.Core.Entities;

namespace SD_IKYS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<PerformanceEvaluation> PerformanceEvaluations { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingParticipant> TrainingParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasOne(e => e.Role)
                    .WithMany(e => e.Users)
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Role configuration
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasIndex(e => e.Name).IsUnique();
            });

            // Employee configuration
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TCKN).IsRequired().HasMaxLength(11);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.MiddleName).HasMaxLength(50);
                entity.Property(e => e.PlaceOfBirth).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.Position).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Department).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasIndex(e => e.TCKN).IsUnique();

                entity.HasOne(e => e.Manager)
                    .WithMany(e => e.Subordinates)
                    .HasForeignKey(e => e.ManagerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Employees)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // LeaveRequest configuration
            modelBuilder.Entity<LeaveRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.LeaveType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Reason).HasMaxLength(500);
                entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValue("Pending");
                entity.Property(e => e.ApprovalNotes).HasMaxLength(200);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasOne(e => e.Employee)
                    .WithMany(e => e.LeaveRequests)
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.User)
                    .WithMany(e => e.LeaveRequests)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Approver)
                    .WithMany()
                    .HasForeignKey(e => e.ApproverId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // PerformanceEvaluation configuration
            modelBuilder.Entity<PerformanceEvaluation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.EvaluationPeriod).IsRequired().HasMaxLength(50);
                entity.Property(e => e.WorkQuality).HasDefaultValue(0);
                entity.Property(e => e.Productivity).HasDefaultValue(0);
                entity.Property(e => e.Teamwork).HasDefaultValue(0);
                entity.Property(e => e.Communication).HasDefaultValue(0);
                entity.Property(e => e.Initiative).HasDefaultValue(0);
                entity.Property(e => e.OverallScore).HasColumnType("decimal(3,2)");
                entity.Property(e => e.Strengths).HasMaxLength(1000);
                entity.Property(e => e.AreasForImprovement).HasMaxLength(1000);
                entity.Property(e => e.Goals).HasMaxLength(500);
                entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValue("Draft");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasOne(e => e.Employee)
                    .WithMany(e => e.PerformanceEvaluations)
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.User)
                    .WithMany(e => e.PerformanceEvaluations)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Evaluator)
                    .WithMany()
                    .HasForeignKey(e => e.EvaluatorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Training configuration
            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.TrainingType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Trainer).HasMaxLength(100);
                entity.Property(e => e.Location).HasMaxLength(200);
                entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValue("Planned");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Trainings)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // TrainingParticipant configuration
            modelBuilder.Entity<TrainingParticipant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValue("Registered");
                entity.Property(e => e.Score).HasColumnType("decimal(5,2)");
                entity.Property(e => e.CertificateNumber).HasMaxLength(200);
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasOne(e => e.Training)
                    .WithMany(e => e.Participants)
                    .HasForeignKey(e => e.TrainingId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Employee)
                    .WithMany(e => e.TrainingParticipants)
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.TrainingId, e.EmployeeId }).IsUnique();
            });
        }
    }
} 