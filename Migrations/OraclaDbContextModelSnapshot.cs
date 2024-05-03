﻿// <auto-generated />
using System;
using AvailabilityConfig.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace AvailabilityConfig.Migrations
{
    [DbContext(typeof(OraclaDbContext))]
    partial class OraclaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AvailabilityConfig.Camera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Highway")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("KmComplement")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("LATLNG")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("LastVerification")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Parents")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Status")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Cameras");
                });

            modelBuilder.Entity("AvailabilityConfig.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CameraId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("PingTime")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("PingsToOffline")
                        .HasColumnType("NUMBER(10)");

                    b.Property<float>("Value")
                        .HasColumnType("BINARY_FLOAT");

                    b.Property<double>("VerificationTime")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("currentStatus")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("AvailabilityConfig.Config", b =>
                {
                    b.HasOne("AvailabilityConfig.Camera", "Camera")
                        .WithMany("AvailabilityConfigs")
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");
                });

            modelBuilder.Entity("AvailabilityConfig.Camera", b =>
                {
                    b.Navigation("AvailabilityConfigs");
                });
#pragma warning restore 612, 618
        }
    }
}
