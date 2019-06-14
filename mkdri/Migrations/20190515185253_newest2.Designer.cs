﻿// <auto-generated />
using System;
using MKDRI.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MKDRI.Migrations
{
    [DbContext(typeof(MKDRIContext))]
    [Migration("20190515185253_newest2")]
    partial class newest2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MKDRI.Models.ContactInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnName("Content")
                        .HasColumnType("character varying")
                        .HasMaxLength(250);

                    b.Property<int?>("LaboratoryId");

                    b.Property<int?>("OrganisationId");

                    b.Property<int>("Type")
                        .HasColumnName("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("ContactInformation","main");
                });

            modelBuilder.Entity("MKDRI.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CatalogName")
                        .HasColumnName("CatalogName")
                        .HasColumnType("character varying")
                        .HasMaxLength(200);

                    b.Property<string>("Datasheet")
                        .HasColumnName("DataSheet")
                        .HasColumnType("character varying")
                        .HasMaxLength(300);

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageLink");

                    b.Property<int?>("LaboratoryId");

                    b.Property<string>("Manufacturer")
                        .HasColumnName("Manufacturer")
                        .HasColumnType("character varying")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("character varying")
                        .HasMaxLength(200);

                    b.Property<int>("Year")
                        .HasColumnName("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("Equipment","main");
                });

            modelBuilder.Entity("MKDRI.Models.Laboratory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer");

                    b.Property<int>("City")
                        .HasColumnName("City");

                    b.Property<int?>("CoordinatorId");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("text");

                    b.Property<float>("Latitude")
                        .HasColumnName("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnName("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("character varying")
                        .HasMaxLength(200);

                    b.Property<int?>("OrganisationId");

                    b.Property<int>("Visits")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CoordinatorId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Laboratory","main");
                });

            modelBuilder.Entity("MKDRI.Models.LaboratoryTeam", b =>
                {
                    b.Property<int>("LaboratoryId");

                    b.Property<int>("UserId");

                    b.HasKey("LaboratoryId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("LaboratoryTeam","main");
                });

            modelBuilder.Entity("MKDRI.Models.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("DirectorId");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnName("Image")
                        .HasColumnType("character varying");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("character varying")
                        .HasMaxLength(200);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Organisation","main");
                });

            modelBuilder.Entity("MKDRI.Models.ResearchService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Description");

                    b.Property<int?>("LaboratoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("character varying")
                        .HasMaxLength(200);

                    b.Property<int>("Type")
                        .HasColumnName("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("ResearchService","main");
                });

            modelBuilder.Entity("MKDRI.Models.ResearchServicePerson", b =>
                {
                    b.Property<int>("ResearchServiceId");

                    b.Property<int>("UserId");

                    b.HasKey("ResearchServiceId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ResearchServicePerson","main");
                });

            modelBuilder.Entity("MKDRI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DeletedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(null);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("character varying")
                        .HasMaxLength(250);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("character varying")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasColumnType("character varying")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("User","main");
                });

            modelBuilder.Entity("MKDRI.Models.ContactInformation", b =>
                {
                    b.HasOne("MKDRI.Models.Laboratory", "Laboratory")
                        .WithMany("ContactInformation")
                        .HasForeignKey("LaboratoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MKDRI.Models.Organisation", "Organisation")
                        .WithMany("ContactInformation")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MKDRI.Models.Equipment", b =>
                {
                    b.HasOne("MKDRI.Models.Laboratory", "Laboratory")
                        .WithMany("Equipment")
                        .HasForeignKey("LaboratoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MKDRI.Models.Laboratory", b =>
                {
                    b.HasOne("MKDRI.Models.User", "Coordinator")
                        .WithMany()
                        .HasForeignKey("CoordinatorId");

                    b.HasOne("MKDRI.Models.Organisation", "Organisation")
                        .WithMany("Laboratories")
                        .HasForeignKey("OrganisationId");
                });

            modelBuilder.Entity("MKDRI.Models.LaboratoryTeam", b =>
                {
                    b.HasOne("MKDRI.Models.Laboratory", "Laboratory")
                        .WithMany("Team")
                        .HasForeignKey("LaboratoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MKDRI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MKDRI.Models.Organisation", b =>
                {
                    b.HasOne("MKDRI.Models.User", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId");
                });

            modelBuilder.Entity("MKDRI.Models.ResearchService", b =>
                {
                    b.HasOne("MKDRI.Models.Laboratory", "Laboratory")
                        .WithMany("ResearchServices")
                        .HasForeignKey("LaboratoryId");
                });

            modelBuilder.Entity("MKDRI.Models.ResearchServicePerson", b =>
                {
                    b.HasOne("MKDRI.Models.ResearchService", "ResearchService")
                        .WithMany("Persons")
                        .HasForeignKey("ResearchServiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MKDRI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}