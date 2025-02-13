﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Robot.Repository.Entities;

#nullable disable

namespace Robot.Repository.Migrations
{
    [DbContext(typeof(FactoryManagementContext))]
    partial class FactoryManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "Role", new[] { "Admin", "Employee" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Robot.Repository.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("LogID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Action");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("Details");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDelete");

                    b.Property<int>("TaskId")
                        .HasColumnType("integer")
                        .HasColumnName("TaskID");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("TimeStamp");

                    b.HasKey("Id")
                        .HasName("PK_Log");

                    b.HasIndex("TaskId");

                    b.ToTable("Log", (string)null);
                });

            modelBuilder.Entity("Robot.Repository.Entities.Maintenance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("MaintenanceID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDelete");

                    b.Property<int>("RobotId")
                        .HasColumnType("integer")
                        .HasColumnName("RobotID");

                    b.Property<string>("Technician")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Technician");

                    b.HasKey("Id")
                        .HasName("PK_Maintenance");

                    b.HasIndex("RobotId");

                    b.ToTable("Maintenance", (string)null);
                });

            modelBuilder.Entity("Robot.Repository.Entities.Operator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("OperatorID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("ContactInfo");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDelete");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Shift")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Shift");

                    b.HasKey("Id")
                        .HasName("PK_Operator");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("Robot.Repository.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ProductID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Dimensions");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDelete");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Material");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PK_Product");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Robot.Repository.Entities.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("RobotID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDelete");

                    b.Property<DateTime?>("LastMaintenanceDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastMaintenanceDate");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Model");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("Position");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Status");

                    b.HasKey("Id")
                        .HasName("PK_Robot");

                    b.ToTable("Robot", (string)null);
                });

            modelBuilder.Entity("Robot.Repository.Entities.RobotTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("TaskID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("EndTime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDelete");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("ProductID");

                    b.Property<int>("RobotId")
                        .HasColumnType("integer")
                        .HasColumnName("RobotID");

                    b.Property<int?>("StampId")
                        .HasColumnType("integer")
                        .HasColumnName("StampID");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("StartTime");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Status");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_Tasks");

                    b.HasIndex("ProductId");

                    b.HasIndex("RobotId");

                    b.HasIndex("StampId");

                    b.HasIndex("UserId");

                    b.ToTable("RobotTasks");
                });

            modelBuilder.Entity("Robot.Repository.Entities.Stamp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("StampID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("InkColor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("InkColor");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDelete");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("Size");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Type");

                    b.HasKey("Id")
                        .HasName("PK_Stamp");

                    b.ToTable("Stamp", (string)null);
                });

            modelBuilder.Entity("Robot.Repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("UserID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CodeOTPEmail")
                        .HasColumnType("integer")
                        .HasColumnName("CodeOTPEmail");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("FullName");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Passwork");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Phone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("UserName");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Robot.Repository.Entities.Log", b =>
                {
                    b.HasOne("Robot.Repository.Entities.RobotTask", "Task")
                        .WithMany("Logs")
                        .HasForeignKey("TaskId")
                        .IsRequired()
                        .HasConstraintName("FK_Log_TaskID");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Robot.Repository.Entities.Maintenance", b =>
                {
                    b.HasOne("Robot.Repository.Entities.Robot", "Robot")
                        .WithMany("Maintenances")
                        .HasForeignKey("RobotId")
                        .IsRequired()
                        .HasConstraintName("FK_Maintenance_Robot");

                    b.Navigation("Robot");
                });

            modelBuilder.Entity("Robot.Repository.Entities.RobotTask", b =>
                {
                    b.HasOne("Robot.Repository.Entities.Product", "Product")
                        .WithMany("Tasks")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Tasks_Product");

                    b.HasOne("Robot.Repository.Entities.Robot", "Robot")
                        .WithMany("Tasks")
                        .HasForeignKey("RobotId")
                        .IsRequired()
                        .HasConstraintName("FK_Tasks_Robot");

                    b.HasOne("Robot.Repository.Entities.Stamp", "Stamp")
                        .WithMany("Tasks")
                        .HasForeignKey("StampId")
                        .HasConstraintName("FK_Tasks_Stamp");

                    b.HasOne("Robot.Repository.Entities.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Tasks_User");

                    b.Navigation("Product");

                    b.Navigation("Robot");

                    b.Navigation("Stamp");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Robot.Repository.Entities.Product", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Robot.Repository.Entities.Robot", b =>
                {
                    b.Navigation("Maintenances");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Robot.Repository.Entities.RobotTask", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Robot.Repository.Entities.Stamp", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Robot.Repository.Entities.User", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
