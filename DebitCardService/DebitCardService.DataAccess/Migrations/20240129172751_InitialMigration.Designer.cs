﻿// <auto-generated />
using System;
using DebitCardService.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DebitCardService.DataAccess.Migrations
{
    [DbContext(typeof(DebitCardServiceStorageContext))]
    [Migration("20240129172751_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DebitCardService.DataAccess.Entities.DebitCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardHolder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CashWithdrawalLimit")
                        .HasColumnType("int");

                    b.Property<int>("Cvv2Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirityDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActiveByPayPass")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActiveByPhone")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActiveCashWithdrawal")
                        .HasColumnType("bit");

                    b.Property<int>("PayPassLimit")
                        .HasColumnType("int");

                    b.Property<int>("PhoneLimit")
                        .HasColumnType("int");

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DebitCards");
                });
#pragma warning restore 612, 618
        }
    }
}
