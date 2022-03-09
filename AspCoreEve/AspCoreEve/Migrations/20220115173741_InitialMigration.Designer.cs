﻿// <auto-generated />
using System;
using AspCoreEve.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspCoreEve.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220115173741_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AspCoreEve.Models.BusInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Bus_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cid")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SitAvailable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Cid");

                    b.ToTable("BusInformations");
                });

            modelBuilder.Entity("AspCoreEve.Models.Catagory", b =>
                {
                    b.Property<int>("Cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CatagoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cid");

                    b.ToTable("Catagories");
                });

            modelBuilder.Entity("AspCoreEve.Models.BusInformation", b =>
                {
                    b.HasOne("AspCoreEve.Models.Catagory", "Catagory")
                        .WithMany("BusInformation")
                        .HasForeignKey("Cid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catagory");
                });

            modelBuilder.Entity("AspCoreEve.Models.Catagory", b =>
                {
                    b.Navigation("BusInformation");
                });
#pragma warning restore 612, 618
        }
    }
}