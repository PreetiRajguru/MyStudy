﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trial.Data.Context;

namespace Trial.Data.Migrations
{
    [DbContext(typeof(MatterDbContext))]
    [Migration("20230424084220_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trial.Data.Models.Attorney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MatterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatterId")
                        .IsUnique();

                    b.ToTable("Attorneys");
                });

            modelBuilder.Entity("Trial.Data.Models.AttorneyInvoice", b =>
                {
                    b.Property<int>("AttorneyId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("AttorneyId", "InvoiceId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("AttorneyInvoices");
                });

            modelBuilder.Entity("Trial.Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Trial.Data.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HoursWorked")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MatterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatterId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Trial.Data.Models.Jurisdiction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttorneyId")
                        .HasColumnType("int");

                    b.Property<int>("MatterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AttorneyId");

                    b.HasIndex("MatterId")
                        .IsUnique();

                    b.ToTable("Jurisdictions");
                });

            modelBuilder.Entity("Trial.Data.Models.Matter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Matters");
                });

            modelBuilder.Entity("Trial.Data.Models.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttorneyId")
                        .HasColumnType("int");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttorneyId")
                        .IsUnique();

                    b.HasIndex("InvoiceId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("Trial.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttorneyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AttorneyId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Trial.Data.Models.Attorney", b =>
                {
                    b.HasOne("Trial.Data.Models.Matter", "Matter")
                        .WithOne("Attorney")
                        .HasForeignKey("Trial.Data.Models.Attorney", "MatterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Matter");
                });

            modelBuilder.Entity("Trial.Data.Models.AttorneyInvoice", b =>
                {
                    b.HasOne("Trial.Data.Models.Attorney", null)
                        .WithMany()
                        .HasForeignKey("AttorneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trial.Data.Models.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Trial.Data.Models.Invoice", b =>
                {
                    b.HasOne("Trial.Data.Models.Matter", "Matter")
                        .WithMany("Invoices")
                        .HasForeignKey("MatterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Matter");
                });

            modelBuilder.Entity("Trial.Data.Models.Jurisdiction", b =>
                {
                    b.HasOne("Trial.Data.Models.Attorney", "Attorney")
                        .WithMany("Jurisdictions")
                        .HasForeignKey("AttorneyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trial.Data.Models.Matter", "Matter")
                        .WithOne("Jurisdiction")
                        .HasForeignKey("Trial.Data.Models.Jurisdiction", "MatterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Attorney");

                    b.Navigation("Matter");
                });

            modelBuilder.Entity("Trial.Data.Models.Matter", b =>
                {
                    b.HasOne("Trial.Data.Models.Client", "Client")
                        .WithMany("Matters")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Trial.Data.Models.Rate", b =>
                {
                    b.HasOne("Trial.Data.Models.Attorney", "Attorney")
                        .WithOne("Rate")
                        .HasForeignKey("Trial.Data.Models.Rate", "AttorneyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trial.Data.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Attorney");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Trial.Data.Models.Role", b =>
                {
                    b.HasOne("Trial.Data.Models.Attorney", "Attorney")
                        .WithMany("Roles")
                        .HasForeignKey("AttorneyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Attorney");
                });

            modelBuilder.Entity("Trial.Data.Models.Attorney", b =>
                {
                    b.Navigation("Jurisdictions");

                    b.Navigation("Rate")
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Trial.Data.Models.Client", b =>
                {
                    b.Navigation("Matters");
                });

            modelBuilder.Entity("Trial.Data.Models.Matter", b =>
                {
                    b.Navigation("Attorney")
                        .IsRequired();

                    b.Navigation("Invoices");

                    b.Navigation("Jurisdiction")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
