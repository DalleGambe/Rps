﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rps.DAL;

#nullable disable

namespace Rps.DAL.Migrations
{
    [DbContext(typeof(RpsDataContext))]
    [Migration("20231121094601_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("TotalScore")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Players");
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

                    b.Property<int>("ScorePlayer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScoreRobot")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerInMatchId");

                    b.ToTable("RpsMatchesPlayed");
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

                    b.ToTable("AppSetting");
                });

            modelBuilder.Entity("Rps.Domain.RpsMatch", b =>
                {
                    b.HasOne("Rps.Domain.Player", "PlayerInMatch")
                        .WithMany("RpsMatches")
                        .HasForeignKey("PlayerInMatchId");

                    b.Navigation("PlayerInMatch");
                });

            modelBuilder.Entity("Rps.Domain.Player", b =>
                {
                    b.Navigation("RpsMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
