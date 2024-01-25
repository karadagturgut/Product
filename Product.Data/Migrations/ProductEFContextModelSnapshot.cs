﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Data.Context;

#nullable disable

namespace Product.Data.Migrations
{
    [DbContext(typeof(ProductEFContext))]
    partial class ProductEFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Product.Entity.ManualLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IP");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MethodName");

                    b.Property<string>("Request")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Request");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Response");

                    b.Property<DateTime>("TranDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("TranDate");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Product.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Product_Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Product_Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("tbl_Product");
                });

            modelBuilder.Entity("Product.Entity.ResourceText", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ResourceKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ResourceKey");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("ResourceText");
                });
#pragma warning restore 612, 618
        }
    }
}
