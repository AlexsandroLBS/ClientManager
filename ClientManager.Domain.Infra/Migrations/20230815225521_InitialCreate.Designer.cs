﻿// <auto-generated />
using System;
using ClientManager.Domain.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientManager.Domain.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230815225521_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientManager.Domain.Entities.Client", b =>
                {
                    b.Property<int>("ClientCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientCode"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DocumentNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClientCode");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("ClientManager.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArrivedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Canceled")
                        .HasColumnType("bit");

                    b.Property<int>("ClientCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VendorCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientCode");

                    b.HasIndex("VendorCode");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("ClientManager.Domain.Entities.Vendor", b =>
                {
                    b.Property<int>("VendorCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorCode"));

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VendorCode");

                    b.ToTable("Vendors", (string)null);
                });

            modelBuilder.Entity("ClientManager.Domain.Entities.Order", b =>
                {
                    b.HasOne("ClientManager.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientManager.Domain.Entities.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Vendor");
                });
#pragma warning restore 612, 618
        }
    }
}