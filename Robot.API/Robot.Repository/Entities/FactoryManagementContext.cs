using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Robot.Repository.Entities;

public partial class FactoryManagementContext : DbContext
{
    public FactoryManagementContext()
    {

    }

    public FactoryManagementContext(DbContextOptions<FactoryManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Robot> Robots { get; set; }

    public virtual DbSet<Stamp> Stamps { get; set; }

    public virtual DbSet<RobotTask> RobotTasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("Role", new[] { "Admin", "Employee" });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.ToTable("User");

            entity.Property(e =>  e.Id).HasColumnName("UserID").ValueGeneratedOnAdd();
            entity.Property(e => e.FullName).HasColumnName("FullName");
            entity.Property(e => e.Phone).HasColumnName("Phone");
            entity.Property(e => e.Email).HasColumnName("Email");
            entity.Property(e => e.UserName).HasColumnName("UserName");
            entity.Property(e => e.Password).HasColumnName("Passwork");
            entity.Property(e => e.CodeOTPEmail).HasColumnName("CodeOTPEmail");
            entity.Property(e => e.Role).HasColumnName("Role").HasConversion<string>();
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted");


        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Log");

            entity.ToTable("Log");

            entity.Property(e => e.Id).HasColumnName("LogID").ValueGeneratedOnAdd();
            entity.Property(e => e.Timestamp).HasColumnType("timestamp with time zone").HasColumnName("TimeStamp");
            entity.Property(e => e.Action)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Action");
            entity.Property(e => e.Details).HasMaxLength(255).HasColumnName("Details");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDelete");
            
            entity.HasOne(d => d.Task).WithMany(p => p.Logs)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_TaskID");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Maintenance");

            entity.ToTable("Maintenance");

            entity.Property(e => e.Id).HasColumnName("MaintenanceID").ValueGeneratedOnAdd();
            entity.Property(e => e.Date).HasColumnType("timestamp with time zone").HasColumnName("Date");
            entity.Property(e => e.Technician)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Technician");
            entity.Property(e => e.Description).HasMaxLength(100).HasColumnName("Description");
            entity.Property(e => e.RobotId).HasColumnName("RobotID");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDelete");

            entity.HasOne(d => d.Robot).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.RobotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maintenance_Robot");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Operator");

            entity.Property(e => e.Id).HasColumnName("OperatorID").ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Name");
            entity.Property(e => e.Shift)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Shift");
            entity.Property(e => e.ContactInfo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ContactInfo");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDelete");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Product");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ProductID").ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Name");
            entity.Property(e => e.Dimensions)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Dimensions");
            entity.Property(e => e.Material)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Material");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDelete");
        });

        modelBuilder.Entity<Robot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Robot");

            entity.ToTable("Robot");

            entity.Property(e => e.Id).HasColumnName("RobotID").ValueGeneratedOnAdd();
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Model");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Status");
            entity.Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Position");
            entity.Property(e => e.LastMaintenanceDate).HasColumnType("timestamp with time zone").HasColumnName("LastMaintenanceDate");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDelete");
        });

        modelBuilder.Entity<Stamp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Stamp");

            entity.ToTable("Stamp");

            entity.Property(e => e.Id).HasColumnName("StampID").ValueGeneratedOnAdd();
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Type");
            entity.Property(e => e.Size)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Size");
            entity.Property(e => e.InkColor)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("InkColor");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDelete");
        });

        modelBuilder.Entity<RobotTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tasks");

            entity.Property(e => e.Id).HasColumnName("TaskID").ValueGeneratedOnAdd();
            entity.Property(e => e.StartTime).HasColumnType("timestamp with time zone").HasColumnName("StartTime");
            entity.Property(e => e.EndTime).HasColumnType("timestamp with time zone").HasColumnName("EndTime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Status");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDelete");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.RobotId).HasColumnName("RobotID");
            entity.Property(e => e.StampId).HasColumnName("StampID");

            entity.HasOne(d => d.Product).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Tasks_Product");

            entity.HasOne(d => d.Robot).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.RobotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Robot");

            entity.HasOne(d => d.Stamp).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StampId)
                .HasConstraintName("FK_Tasks_Stamp");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Tasks_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}