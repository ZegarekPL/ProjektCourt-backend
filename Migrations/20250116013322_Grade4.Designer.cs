﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using project_court_backend.Configuration;

#nullable disable

namespace project_court_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250116013322_Grade4")]
    partial class Grade4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("project_court_backend.Models.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CourtId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourtId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("project_court_backend.Models.Entity.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("localization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("surfaceType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Court");
                });

            modelBuilder.Entity("project_court_backend.Models.Entity.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourtId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<double>("grade")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CourtId");

                    b.HasIndex("UserId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("project_court_backend.Models.Entity.SurfaceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("surfaceType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SurfaceType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            surfaceType = "Trawiaste"
                        },
                        new
                        {
                            Id = 2,
                            surfaceType = "Mączka"
                        },
                        new
                        {
                            Id = 3,
                            surfaceType = "Akryl"
                        });
                });

            modelBuilder.Entity("project_court_backend.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("project_court_backend.Models.Entity.Comment", b =>
                {
                    b.HasOne("project_court_backend.Models.Entity.Court", "Court")
                        .WithMany("comments")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Court");
                });

            modelBuilder.Entity("project_court_backend.Models.Entity.Grade", b =>
                {
                    b.HasOne("project_court_backend.Models.Entity.Court", "court")
                        .WithMany("grades")
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project_court_backend.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("court");
                });

            modelBuilder.Entity("project_court_backend.Models.Entity.Court", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("grades");
                });
#pragma warning restore 612, 618
        }
    }
}
