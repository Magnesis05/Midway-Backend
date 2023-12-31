﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231214103153_Fourth")]
    partial class Fourth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Backend.Models.Allergies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("Backend.Models.Bookings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("accepted_by_manager")
                        .HasColumnType("bit");

                    b.Property<int>("booking_restaurant_idId")
                        .HasColumnType("int");

                    b.Property<DateTime>("booking_time_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("booking_time_from")
                        .HasColumnType("datetime2");

                    b.Property<int>("booking_user_idId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("number_of_table")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("booking_restaurant_idId");

                    b.HasIndex("booking_user_idId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Backend.Models.Restaurants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("cuisine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone_number")
                        .HasColumnType("int");

                    b.Property<string>("type_of_user")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RestaurantsAddresses", b =>
                {
                    b.Property<int>("AddressIdId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantsId")
                        .HasColumnType("int");

                    b.HasKey("AddressIdId", "RestaurantsId");

                    b.HasIndex("RestaurantsId");

                    b.ToTable("RestaurantsAddresses");
                });

            modelBuilder.Entity("UsersAllergies", b =>
                {
                    b.Property<int>("AllergiesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("AllergiesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UsersAllergies");
                });

            modelBuilder.Entity("Backend.Models.Bookings", b =>
                {
                    b.HasOne("Backend.Models.Restaurants", "booking_restaurant_id")
                        .WithMany("Bookings_Id")
                        .HasForeignKey("booking_restaurant_idId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "booking_user_id")
                        .WithMany("Bookings_Id")
                        .HasForeignKey("booking_user_idId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("booking_restaurant_id");

                    b.Navigation("booking_user_id");
                });

            modelBuilder.Entity("RestaurantsAddresses", b =>
                {
                    b.HasOne("Backend.Models.Address", null)
                        .WithMany()
                        .HasForeignKey("AddressIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Restaurants", null)
                        .WithMany()
                        .HasForeignKey("RestaurantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UsersAllergies", b =>
                {
                    b.HasOne("Backend.Models.Allergies", null)
                        .WithMany()
                        .HasForeignKey("AllergiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Restaurants", b =>
                {
                    b.Navigation("Bookings_Id");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Navigation("Bookings_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
