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
    [Migration("20240131142405_UpdateUser")]
    partial class UpdateUser
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
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)");

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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DebitCards");
                });

            modelBuilder.Entity("DebitCardService.DataAccess.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)");

                    b.Property<DateTime>("DateOfOperation")
                        .HasColumnType("datetime2");

                    b.Property<int>("DebitCardId")
                        .HasColumnType("int");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("RecipientAccountNumber")
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("nvarchar(26)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("SenderAccountNumber")
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("nvarchar(26)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DebitCardId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("DebitCardService.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DebitCardService.DataAccess.Entities.DebitCard", b =>
                {
                    b.HasOne("DebitCardService.DataAccess.Entities.User", "User")
                        .WithMany("DebitCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DebitCardService.DataAccess.Entities.History", b =>
                {
                    b.HasOne("DebitCardService.DataAccess.Entities.DebitCard", "DebitCard")
                        .WithMany("History")
                        .HasForeignKey("DebitCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DebitCard");
                });

            modelBuilder.Entity("DebitCardService.DataAccess.Entities.DebitCard", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("DebitCardService.DataAccess.Entities.User", b =>
                {
                    b.Navigation("DebitCards");
                });
#pragma warning restore 612, 618
        }
    }
}