﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetAdoptionAPI.Data;

#nullable disable

namespace PetAdoptionAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250301211554_makeUserOptional")]
    partial class makeUserOptional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetAdoptionAPI.Models.AdoptionRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PetID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PetID");

                    b.HasIndex("UserID");

                    b.ToTable("AdoptionRequests");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("MessageThreadID")
                        .HasColumnType("int");

                    b.Property<int>("SenderID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MessageThreadID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.MessageThread", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AdoptionRequestID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AdoptionRequestID")
                        .IsUnique();

                    b.ToTable("MessageThreads");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.Pet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetShelterID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PetShelterID");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.PetImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PetID");

                    b.ToTable("PetImages");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.PetShelter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("PetShelters");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Provider")
                        .HasColumnType("int");

                    b.Property<string>("ProviderID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.AdoptionRequest", b =>
                {
                    b.HasOne("PetAdoptionAPI.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetAdoptionAPI.Models.User", "User")
                        .WithMany("AdoptionRequests")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.Message", b =>
                {
                    b.HasOne("PetAdoptionAPI.Models.MessageThread", "MessageThread")
                        .WithMany("Messages")
                        .HasForeignKey("MessageThreadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MessageThread");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.MessageThread", b =>
                {
                    b.HasOne("PetAdoptionAPI.Models.AdoptionRequest", "AdoptionRequest")
                        .WithOne("MessageThread")
                        .HasForeignKey("PetAdoptionAPI.Models.MessageThread", "AdoptionRequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdoptionRequest");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.Pet", b =>
                {
                    b.HasOne("PetAdoptionAPI.Models.PetShelter", "PetShelter")
                        .WithMany("Pets")
                        .HasForeignKey("PetShelterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetShelter");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.PetImage", b =>
                {
                    b.HasOne("PetAdoptionAPI.Models.Pet", "Pet")
                        .WithMany("Images")
                        .HasForeignKey("PetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.PetShelter", b =>
                {
                    b.HasOne("PetAdoptionAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.AdoptionRequest", b =>
                {
                    b.Navigation("MessageThread")
                        .IsRequired();
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.MessageThread", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.Pet", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.PetShelter", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetAdoptionAPI.Models.User", b =>
                {
                    b.Navigation("AdoptionRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
