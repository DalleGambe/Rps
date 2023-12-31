﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rps.DAL;

#nullable disable

namespace Rps.DAL.Migrations
{
    [DbContext(typeof(RpsDataContext))]
    partial class RpsDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Rps.Domain.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesWon")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("Rps.Domain.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesWon")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("RobotName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Robots", (string)null);
                });

            modelBuilder.Entity("Rps.Domain.RpsMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatePlayed")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlayerInMatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RobotInMatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundsPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScorePlayer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScoreRobot")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerInMatchId");

                    b.HasIndex("RobotInMatchId");

                    b.ToTable("RpsMatchesPlayed", (string)null);
                });

            modelBuilder.Entity("Rps.Domain.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("MasterVolume")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AppSettings", (string)null);
                });

            modelBuilder.Entity("Rps.Domain.RpsMatch", b =>
                {
                    b.HasOne("Rps.Domain.Player", "PlayerInMatch")
                        .WithMany("RpsMatches")
                        .HasForeignKey("PlayerInMatchId");

                    b.HasOne("Rps.Domain.Robot", "RobotInMatch")
                        .WithMany("RpsMatches")
                        .HasForeignKey("RobotInMatchId");

                    b.Navigation("PlayerInMatch");

                    b.Navigation("RobotInMatch");
                });

            modelBuilder.Entity("Rps.Domain.Player", b =>
                {
                    b.Navigation("RpsMatches");
                });

            modelBuilder.Entity("Rps.Domain.Robot", b =>
                {
                    b.Navigation("RpsMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
