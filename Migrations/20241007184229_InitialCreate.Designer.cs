﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using c_sharp.Data;

#nullable disable

namespace c_sharp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241007184229_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("c_sharp.Models.User.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("f8fc8e02-c7fa-4066-9150-c0989d29964b"),
                            CreatedAt = new DateTime(2024, 10, 7, 20, 42, 27, 349, DateTimeKind.Local).AddTicks(9675),
                            Email = "bamse.stark@mail.com",
                            FirstName = "Bamse",
                            HashPassword = "$2a$11$mMT.tFsQVHaG1DEaVoSRkuwzepTvCJfjv3G5//mLs7DKiCIpLf6RS",
                            LastName = "Stark"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
