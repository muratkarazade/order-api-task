﻿// <auto-generated />
using System;
using ECO.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECO.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230411194436_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ECO.Domain.Entities.Carrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarrierConfigurationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PlusDesiCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("ECO.Domain.Entities.CarrierConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("MaxDesi")
                        .HasColumnType("int");

                    b.Property<int>("MinDesi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId")
                        .IsUnique();

                    b.ToTable("CarrierConfigurations");
                });

            modelBuilder.Entity("ECO.Domain.Entities.CarrierReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CarrierReportDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("CarrierReports");
                });

            modelBuilder.Entity("ECO.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderCarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderDesi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ECO.Domain.Entities.CarrierConfiguration", b =>
                {
                    b.HasOne("ECO.Domain.Entities.Carrier", "Carrier")
                        .WithOne("CarrierConfiguration")
                        .HasForeignKey("ECO.Domain.Entities.CarrierConfiguration", "CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("ECO.Domain.Entities.CarrierReport", b =>
                {
                    b.HasOne("ECO.Domain.Entities.Carrier", "Carrier")
                        .WithMany("CarrierReports")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("ECO.Domain.Entities.Order", b =>
                {
                    b.HasOne("ECO.Domain.Entities.Carrier", "Carrier")
                        .WithMany("Orders")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("ECO.Domain.Entities.Carrier", b =>
                {
                    b.Navigation("CarrierConfiguration")
                        .IsRequired();

                    b.Navigation("CarrierReports");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
