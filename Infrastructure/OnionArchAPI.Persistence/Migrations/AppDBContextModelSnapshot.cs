﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnionArchAPI.Persistence.Context;

#nullable disable

namespace OnionArchAPI.Persistence.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("OnionArchAPI.Domen.Entitys.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(92),
                            IsDelete = false,
                            Name = "Defakto"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(97),
                            IsDelete = false,
                            Name = "Kigili"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(99),
                            IsDelete = false,
                            Name = "Rodrigos"
                        });
                });

            modelBuilder.Entity("OnionArchAPI.Domen.Entitys.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3341),
                            IsDelete = false,
                            Name = "Electronika",
                            ParentId = 0,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3346),
                            IsDelete = false,
                            Name = "Notebook",
                            ParentId = 1,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3347),
                            IsDelete = false,
                            Name = "Phone",
                            ParentId = 1,
                            Priorty = 2
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3349),
                            IsDelete = false,
                            Name = "Geyim",
                            ParentId = 0,
                            Priorty = 3
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3351),
                            IsDelete = false,
                            Name = "Tshort",
                            ParentId = 4,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 6,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(3352),
                            IsDelete = false,
                            Name = "Cins",
                            ParentId = 4,
                            Priorty = 2
                        });
                });

            modelBuilder.Entity("OnionArchAPI.Domen.Entitys.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(6000),
                            Description = "Cotton",
                            IsDelete = false,
                            Title = "Material"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(6007),
                            Description = "8gb",
                            IsDelete = false,
                            Title = "Ram"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 6,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(6009),
                            Description = "125sm",
                            IsDelete = false,
                            Title = "Uzunluq"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(6011),
                            Description = "50px",
                            IsDelete = false,
                            Title = "Cekilis"
                        });
                });

            modelBuilder.Entity("OnionArchAPI.Domen.Entitys.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(8510),
                            Description = "test",
                            IsDelete = false,
                            Price = 34m,
                            Title = "Kofta"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(8518),
                            Description = "test",
                            IsDelete = false,
                            Price = 158m,
                            Title = "Iphone"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 2,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(8520),
                            Description = "test",
                            IsDelete = false,
                            Price = 346m,
                            Title = "Notebook"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 1,
                            CreateDate = new DateTime(2024, 6, 25, 8, 26, 44, 837, DateTimeKind.Utc).AddTicks(8522),
                            Description = "test",
                            IsDelete = false,
                            Price = 12m,
                            Title = "salvar"
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("OnionArchAPI.Domen.Entitys.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnionArchAPI.Domen.Entitys.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnionArchAPI.Domen.Entitys.Detail", b =>
                {
                    b.HasOne("OnionArchAPI.Domen.Entitys.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnionArchAPI.Domen.Entitys.Product", b =>
                {
                    b.HasOne("OnionArchAPI.Domen.Entitys.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("OnionArchAPI.Domen.Entitys.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnionArchAPI.Domen.Entitys.Category", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
