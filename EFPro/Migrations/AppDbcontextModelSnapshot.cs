﻿// <auto-generated />
using System;
using EFPro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFPro.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    partial class AppDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFPro.Models.Club", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("leagueid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("leagueid");

                    b.ToTable("clubs");
                });

            modelBuilder.Entity("EFPro.Models.Game", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("round")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("startTime")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("games");
                });

            modelBuilder.Entity("EFPro.Models.GamePlayer", b =>
                {
                    b.Property<int>("playerid")
                        .HasColumnType("int");

                    b.Property<int>("gameid")
                        .HasColumnType("int");

                    b.HasKey("playerid", "gameid");

                    b.HasIndex("gameid");

                    b.ToTable("GamePlayer");
                });

            modelBuilder.Entity("EFPro.Models.League", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("leagues");
                });

            modelBuilder.Entity("EFPro.Models.Players", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Clubid")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthDay")
                        .HasColumnType("date");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("resumeid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Clubid");

                    b.ToTable("players");
                });

            modelBuilder.Entity("EFPro.Models.Resume", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("playerid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("playerid")
                        .IsUnique();

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("EFPro.Models.Club", b =>
                {
                    b.HasOne("EFPro.Models.League", "league")
                        .WithMany()
                        .HasForeignKey("leagueid");
                });

            modelBuilder.Entity("EFPro.Models.GamePlayer", b =>
                {
                    b.HasOne("EFPro.Models.Game", "game")
                        .WithMany("gamePlayers")
                        .HasForeignKey("gameid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFPro.Models.Players", "player")
                        .WithMany("gamePlayers")
                        .HasForeignKey("playerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFPro.Models.Players", b =>
                {
                    b.HasOne("EFPro.Models.Club", null)
                        .WithMany("players")
                        .HasForeignKey("Clubid");
                });

            modelBuilder.Entity("EFPro.Models.Resume", b =>
                {
                    b.HasOne("EFPro.Models.Players", "players")
                        .WithOne("resume")
                        .HasForeignKey("EFPro.Models.Resume", "playerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}