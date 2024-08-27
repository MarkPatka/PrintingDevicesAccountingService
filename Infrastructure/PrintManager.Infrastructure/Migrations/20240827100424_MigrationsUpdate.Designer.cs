﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrintManager.Infrastructure.Persistence.DBContexts;

#nullable disable

namespace PrintManager.Infrastructure.Migrations
{
    [DbContext(typeof(PrintManagementDbContext))]
    [Migration("20240827100424_MigrationsUpdate")]
    partial class MigrationsUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrintManager.Domain.DepartmentAggregate.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("PrintManager.Domain.DepartmentAggregate.Department", b =>
                {
                    b.OwnsMany("PrintManager.Domain.DepartmentAggregate.Entities.DepartmentPrintDevice", "PrintDevices", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ConnectionType")
                                .HasColumnType("tinyint");

                            b1.Property<Guid>("DepartmentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("InnerName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<bool>("IsDefaultDevice")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bit")
                                .HasDefaultValue(false);

                            b1.Property<string>("OriginalName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<byte>("SerialNumber")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("tinyint")
                                .HasDefaultValue((byte)1);

                            b1.HasKey("Id");

                            b1.HasIndex("DepartmentId");

                            b1.ToTable("DepartmentDevices", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DepartmentId");

                            b1.OwnsMany("PrintManager.Domain.DepartmentAggregate.Entities.MAC", "MACs", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("DepartmentPrintDeviceId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<byte[]>("MacAddress")
                                        .IsRequired()
                                        .HasColumnType("binary(6)");

                                    b2.HasKey("Id");

                                    b2.HasIndex("DepartmentPrintDeviceId");

                                    b2.ToTable("MACAddresses", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("DepartmentPrintDeviceId");
                                });

                            b1.Navigation("MACs");
                        });

                    b.OwnsMany("PrintManager.Domain.DepartmentAggregate.Entities.Employee", "Employees", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("EmployeeId");

                            b1.Property<Guid>("DepartmentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("JobTitle")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id", "DepartmentId");

                            b1.HasIndex("DepartmentId");

                            b1.ToTable("Employees", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DepartmentId");
                        });

                    b.OwnsMany("PrintManager.Domain.DepartmentAggregate.Entities.PrintSession", "PrintSessions", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("DepartmentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("SessionName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<int>("SessionStatus")
                                .HasColumnType("tinyint");

                            b1.HasKey("Id");

                            b1.HasIndex("DepartmentId");

                            b1.ToTable("Sessions", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DepartmentId");
                        });

                    b.OwnsMany("PrintManager.Domain.InstallationAggregate.Installation", "Installations", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("DepartmentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("DepartmentPrintDeviceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id");

                            b1.HasIndex("DepartmentId");

                            b1.ToTable("Installation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DepartmentId");
                        });

                    b.Navigation("Employees");

                    b.Navigation("Installations");

                    b.Navigation("PrintDevices");

                    b.Navigation("PrintSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
