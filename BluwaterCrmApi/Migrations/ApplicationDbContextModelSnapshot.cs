﻿// <auto-generated />
using System;
using BluwaterCrmApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BluwaterCrmApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BluwaterCrmApi.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<int>("Age");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("CustomerGuid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Dob");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(240);

                    b.Property<string>("FacebookUrl");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<int>("Gender");

                    b.Property<string>("HomePhone");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(240);

                    b.Property<string>("LinkedInUrl");

                    b.Property<string>("MobilePhone");

                    b.Property<int>("OrganizationId");

                    b.Property<int?>("OrganizationId1");

                    b.Property<string>("OwnerId");

                    b.Property<string>("PostalCode");

                    b.Property<string>("ProfileImgUrl");

                    b.Property<string>("State");

                    b.Property<int>("Status");

                    b.Property<string>("TwitterUrl");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("WorkPhone");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerGuid");

                    b.HasIndex("OrganizationId1");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.Deal", b =>
                {
                    b.Property<int>("DealId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ApxValue");

                    b.Property<DateTime>("CreatedTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CustomerId");

                    b.Property<Guid>("DealGuid");

                    b.Property<string>("Description");

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("DealId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DealGuid");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.IndustryTag", b =>
                {
                    b.Property<int>("IndustryTagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("IndustryTagGuid");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("IndustryTagId");

                    b.ToTable("IndustryTags");
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.Interaction", b =>
                {
                    b.Property<int>("InteractionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CustomerId");

                    b.Property<int>("DealId");

                    b.Property<string>("Description");

                    b.Property<Guid>("InteractionGuid");

                    b.Property<string>("OwnerId");

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("InteractionId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DealId");

                    b.HasIndex("InteractionGuid");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CustomerId");

                    b.Property<Guid>("NoteGuid");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("NoteId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NoteGuid");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FacebookUrl");

                    b.Property<int>("IndustryTagId");

                    b.Property<string>("LinkedInUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(240);

                    b.Property<Guid>("OrganizationGuid");

                    b.Property<string>("OwnerId");

                    b.Property<string>("PostalCode");

                    b.Property<string>("ProfileImgUrl");

                    b.Property<string>("State");

                    b.Property<string>("TwitterUrl");

                    b.Property<DateTime>("UpdatedTimestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Website");

                    b.Property<string>("WorkPhone");

                    b.HasKey("OrganizationId");

                    b.HasIndex("IndustryTagId");

                    b.HasIndex("OrganizationGuid");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.Customer", b =>
                {
                    b.HasOne("BluwaterCrmApi.Models.Organization", "Organization")
                        .WithMany("Customers")
                        .HasForeignKey("OrganizationId1");
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.Deal", b =>
                {
                    b.HasOne("BluwaterCrmApi.Models.Customer", "Customer")
                        .WithMany("Deals")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.Interaction", b =>
                {
                    b.HasOne("BluwaterCrmApi.Models.Customer", "Customer")
                        .WithMany("Interactions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BluwaterCrmApi.Models.Deal", "Deal")
                        .WithMany()
                        .HasForeignKey("DealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.Note", b =>
                {
                    b.HasOne("BluwaterCrmApi.Models.Customer", "Customer")
                        .WithMany("Notes")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BluwaterCrmApi.Models.Organization", b =>
                {
                    b.HasOne("BluwaterCrmApi.Models.IndustryTag", "IndustryTag")
                        .WithMany("Organizations")
                        .HasForeignKey("IndustryTagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
