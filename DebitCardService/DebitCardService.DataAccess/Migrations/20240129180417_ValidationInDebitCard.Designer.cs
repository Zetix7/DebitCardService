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
    [Migration("20240129180417_ValidationInDebitCard")]
    partial class ValidationInDebitCard
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
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("nvarchar(26)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("CashWithdrawalLimit")
                        .HasColumnType("int");

                    b.Property<int>("Cvv2Code")
                        .HasMaxLength(3)
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
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DebitCards");
                });
#pragma warning restore 612, 618
        }
    }
}
