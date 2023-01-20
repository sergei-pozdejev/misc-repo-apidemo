﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductApiDemo.Data;

#nullable disable

namespace ProductApiDemo.Data.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230119162404_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductApiDemo.Models.Product", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7025c81b-e44d-4a78-bf6f-914414946a68"),
                            Code = "AB11",
                            ExpirationDate = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Banana chips"
                        },
                        new
                        {
                            Id = new Guid("ade84630-c3d3-462d-a958-c5592916ef76"),
                            Code = "AB12",
                            ExpirationDate = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Apple chips"
                        },
                        new
                        {
                            Id = new Guid("94346c0a-a803-4e27-8749-6ad547cb3978"),
                            Code = "AB13",
                            ExpirationDate = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Potato chips"
                        },
                        new
                        {
                            Id = new Guid("4adb3e6e-55bc-4cd8-aaa5-6f3ef7b3f730"),
                            Code = "BB11",
                            ExpirationDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pineapple"
                        },
                        new
                        {
                            Id = new Guid("777a2917-65ae-47c6-a62d-df53eabbfd2b"),
                            Code = "BB12",
                            ExpirationDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lime"
                        },
                        new
                        {
                            Id = new Guid("e3f3a6da-60db-4818-8e3c-af1787762224"),
                            Code = "BB13",
                            ExpirationDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Apple"
                        },
                        new
                        {
                            Id = new Guid("a58c5b46-3ea5-41d6-8467-10dca04ab0fa"),
                            Code = "BB14",
                            ExpirationDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Banana"
                        },
                        new
                        {
                            Id = new Guid("2a02dd05-604f-41c0-8be2-9a0251575523"),
                            Code = "CB11",
                            ExpirationDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chocolade"
                        },
                        new
                        {
                            Id = new Guid("0b1a02c2-0c71-49b3-a374-0b0745af2ffc"),
                            Code = "CB12",
                            ExpirationDate = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Cereal"
                        },
                        new
                        {
                            Id = new Guid("f9becdc8-a694-48cd-8245-19e254fb049b"),
                            Code = "CB13",
                            ExpirationDate = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Vanilla cookies"
                        },
                        new
                        {
                            Id = new Guid("bd61b7dc-e4af-4940-a468-5fcd9093ae10"),
                            Code = "CB14",
                            ExpirationDate = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chocolade cookies"
                        },
                        new
                        {
                            Id = new Guid("24529d6e-e0ea-4d52-8c27-fb8b9e003cba"),
                            Code = "CB15",
                            ExpirationDate = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Strawberry cookies"
                        },
                        new
                        {
                            Id = new Guid("9533ec53-0d6a-4264-8034-bb62f11df282"),
                            Code = "DB11",
                            ExpirationDate = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Water"
                        },
                        new
                        {
                            Id = new Guid("adbfdf00-315e-4d2f-9d9f-608d336e46a5"),
                            Code = "DB12",
                            ExpirationDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sparkling water"
                        },
                        new
                        {
                            Id = new Guid("357380fe-9f42-43ab-89d9-6d92bfab1a30"),
                            Code = "DB13",
                            ExpirationDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Limonade"
                        },
                        new
                        {
                            Id = new Guid("e8fa1755-5c55-41ae-a822-5a0bad0fe65f"),
                            Code = "EB11",
                            ExpirationDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Vanilla icecream"
                        },
                        new
                        {
                            Id = new Guid("79b37c8a-250d-42b3-876f-bc0accbc83fc"),
                            Code = "EB12",
                            ExpirationDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Strawberry icecream"
                        },
                        new
                        {
                            Id = new Guid("b462e0cb-c45c-4956-95ea-9252a234c835"),
                            Code = "EB13",
                            ExpirationDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chocolate icecream"
                        },
                        new
                        {
                            Id = new Guid("e477ccc0-6286-43f9-a9fc-5e9486a6a93d"),
                            Code = "EB14",
                            ExpirationDate = new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pineapple icecream"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
