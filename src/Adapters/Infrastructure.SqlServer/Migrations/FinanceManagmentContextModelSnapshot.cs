﻿// <auto-generated />
using System;
using Infrastructure.SqlServer.Databases.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.SqlServer.Migrations
{
    [DbContext(typeof(FinanceManagmentContext))]
    partial class FinanceManagmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Application.Contracts.ViewModel+BalanceViewModel", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Expense")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable((string)null);

                    b.ToView("BalanceViewModel", (string)null);
                });

            modelBuilder.Entity("Application.Contracts.ViewModel+CategoryViewModel", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Limit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.ToTable((string)null);

                    b.ToView("CategoryViewModel", (string)null);
                });

            modelBuilder.Entity("Application.Contracts.ViewModel+TransactionViewModel", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable((string)null);

                    b.ToView("TransactionViewModel", (string)null);
                });

            modelBuilder.Entity("Domain.Modules.Accounts.Aggregates.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Domain.Modules.Accounts.Entities.Profile.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Profile", (string)null);
                });

            modelBuilder.Entity("Domain.Modules.Budgets.Aggreagates.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReferencePeriod")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Budget", (string)null);
                });

            modelBuilder.Entity("Domain.Modules.Accounts.Aggregates.Account", b =>
                {
                    b.OwnsOne("Domain.Modules.Accounts.ValueObjects.Address.Address", "Address", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .IsUnicode(false)
                                .HasColumnType("varchar(1024)");

                            b1.Property<string>("Complement")
                                .HasMaxLength(1024)
                                .IsUnicode(false)
                                .HasColumnType("varchar(1024)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .IsUnicode(false)
                                .HasColumnType("varchar(1024)");

                            b1.Property<int?>("Number")
                                .HasColumnType("int");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .IsUnicode(false)
                                .HasColumnType("varchar(1024)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .IsUnicode(false)
                                .HasColumnType("varchar(1024)");

                            b1.Property<string>("ZepCode")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .IsUnicode(false)
                                .HasColumnType("varchar(1024)");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId")
                                .IsUnique();

                            b1.ToTable("Address", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Modules.Accounts.Entities.Profile.Profile", b =>
                {
                    b.HasOne("Domain.Modules.Accounts.Aggregates.Account", "Account")
                        .WithOne("Profile")
                        .HasForeignKey("Domain.Modules.Accounts.Entities.Profile.Profile", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Modules.Budgets.Aggreagates.Budget", b =>
                {
                    b.OwnsMany("Domain.Modules.Budgets.ValueObjects.Categories.Category", "Categories", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("BudgetId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Limit")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .IsUnicode(false)
                                .HasColumnType("varchar(1024)");

                            b1.HasKey("Id");

                            b1.HasIndex("BudgetId");

                            b1.ToTable("Category", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("BudgetId");

                            b1.OwnsMany("Domain.Modules.Budgets.ValueObjects.Transactions.Transaction", "Transactions", b2 =>
                                {
                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b2.Property<int>("Id"));

                                    b2.Property<int>("CategoryId")
                                        .HasColumnType("int");

                                    b2.Property<DateTime>("CreateAt")
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(1024)
                                        .IsUnicode(false)
                                        .HasColumnType("varchar(1024)");

                                    b2.Property<decimal>("Value")
                                        .HasColumnType("decimal(18,2)");

                                    b2.HasKey("Id");

                                    b2.HasIndex("CategoryId");

                                    b2.ToTable("Transaction", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("CategoryId");
                                });

                            b1.Navigation("Transactions");
                        });

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Domain.Modules.Accounts.Aggregates.Account", b =>
                {
                    b.Navigation("Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
