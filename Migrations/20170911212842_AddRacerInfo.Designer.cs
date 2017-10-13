﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RallyeTime.Persistence;
using System;

namespace rallyetimenetcoreapi.Migrations
{
    [DbContext(typeof(RallyeDbContext))]
    [Migration("20170911212842_AddRacerInfo")]
    partial class AddRacerInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RallyeTime.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Driver")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Navigator")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RallyeTime.Models.Checkpoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("RaceId");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("Checkpoints");
                });

            modelBuilder.Entity("RallyeTime.Models.CourseSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<int>("CheckpointId");

                    b.Property<int?>("Points");

                    b.Property<string>("TimeActual")
                        .HasMaxLength(8);

                    b.Property<string>("TimeError")
                        .HasMaxLength(8);

                    b.Property<DateTime?>("TimeIn");

                    b.Property<DateTime?>("TimeOut");

                    b.Property<string>("TimeTrue")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CheckpointId");

                    b.ToTable("CourseSections");
                });

            modelBuilder.Entity("RallyeTime.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessCode")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("RallyeTime.Models.Checkpoint", b =>
                {
                    b.HasOne("RallyeTime.Models.Race", "Race")
                        .WithMany("Checkpoints")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RallyeTime.Models.CourseSection", b =>
                {
                    b.HasOne("RallyeTime.Models.Car", "Car")
                        .WithMany("CourseSections")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RallyeTime.Models.Checkpoint", "Checkpoint")
                        .WithMany()
                        .HasForeignKey("CheckpointId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
