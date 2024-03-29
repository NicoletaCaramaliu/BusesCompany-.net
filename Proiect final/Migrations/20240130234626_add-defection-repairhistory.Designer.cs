﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_final.Data;

#nullable disable

namespace Proiect_final.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240130234626_add-defection-repairhistory")]
    partial class adddefectionrepairhistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proiect_final.Models.Adress.Adress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId")
                        .IsUnique();

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Proiect_final.Models.Bus.Bus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("Bus", (string)null);
                });

            modelBuilder.Entity("Proiect_final.Models.Defection.Defection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DefectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("RepairDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Defections");
                });

            modelBuilder.Entity("Proiect_final.Models.Driver.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid?>("BusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Proiect_final.Models.RepairHistory.RepairHistory", b =>
                {
                    b.Property<Guid>("BusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DefectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("BusId", "DefectionId");

                    b.HasIndex("DefectionId");

                    b.ToTable("RepairHistories");
                });

            modelBuilder.Entity("Proiect_final.Models.Adress.Adress", b =>
                {
                    b.HasOne("Proiect_final.Models.Driver.Driver", "Driver")
                        .WithOne("Adress")
                        .HasForeignKey("Proiect_final.Models.Adress.Adress", "DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Proiect_final.Models.Driver.Driver", b =>
                {
                    b.HasOne("Proiect_final.Models.Bus.Bus", "Bus")
                        .WithMany("Drivers")
                        .HasForeignKey("BusId");

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("Proiect_final.Models.RepairHistory.RepairHistory", b =>
                {
                    b.HasOne("Proiect_final.Models.Bus.Bus", "Bus")
                        .WithMany("RepairHistories")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_final.Models.Defection.Defection", "Defection")
                        .WithMany("RepairHistories")
                        .HasForeignKey("DefectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Defection");
                });

            modelBuilder.Entity("Proiect_final.Models.Bus.Bus", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("RepairHistories");
                });

            modelBuilder.Entity("Proiect_final.Models.Defection.Defection", b =>
                {
                    b.Navigation("RepairHistories");
                });

            modelBuilder.Entity("Proiect_final.Models.Driver.Driver", b =>
                {
                    b.Navigation("Adress");
                });
#pragma warning restore 612, 618
        }
    }
}
