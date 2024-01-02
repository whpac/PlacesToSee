﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SzwarcWesolowski.PlacesToSee.DAO.EntityFramework;

#nullable disable

namespace SzwarcWesolowski.PlacesToSee.DAO.EntityFramework.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("SzwarcWesolowski.PlacesToSee.DAO.EntityFramework.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FlagUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SzwarcWesolowski.PlacesToSee.DAO.EntityFramework.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PlaceType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RegionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("RegionId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("SzwarcWesolowski.PlacesToSee.DAO.EntityFramework.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("SzwarcWesolowski.PlacesToSee.DAO.EntityFramework.Place", b =>
                {
                    b.HasOne("SzwarcWesolowski.PlacesToSee.DAO.EntityFramework.Country", null)
                        .WithMany("Places")
                        .HasForeignKey("CountryId");

                    b.HasOne("SzwarcWesolowski.PlacesToSee.DAO.EntityFramework.Region", null)
                        .WithMany("Places")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("SzwarcWesolowski.PlacesToSee.DAO.EntityFramework.Country", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("SzwarcWesolowski.PlacesToSee.DAO.EntityFramework.Region", b =>
                {
                    b.Navigation("Places");
                });
#pragma warning restore 612, 618
        }
    }
}