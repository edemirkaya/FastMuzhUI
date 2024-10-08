﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Master", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedDate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<Guid?>("MasterProfileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Surname");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("MasterProfileId")
                        .IsUnique();

                    b.ToTable("Masters", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MasterProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Adress");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedDate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<Guid>("MasterId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Point")
                        .HasColumnType("numeric");

                    b.Property<string>("ProfilePhoto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("MasterProfiles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ServiceCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletedDate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<Guid?>("ParentServiceCategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ServiceCategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("ServiceCategories", (string)null);
                });

            modelBuilder.Entity("MasterProfileServiceCategory", b =>
                {
                    b.Property<Guid>("MasterProfilesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServiceCategoriesId")
                        .HasColumnType("uuid");

                    b.HasKey("MasterProfilesId", "ServiceCategoriesId");

                    b.HasIndex("ServiceCategoriesId");

                    b.ToTable("MasterProfileServiceCatalogs", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Master", b =>
                {
                    b.HasOne("Domain.Entities.MasterProfile", "MasterProfiles")
                        .WithOne("Masters")
                        .HasForeignKey("Domain.Entities.Master", "MasterProfileId");

                    b.Navigation("MasterProfiles");
                });

            modelBuilder.Entity("Domain.Entities.ServiceCategory", b =>
                {
                    b.HasOne("Domain.Entities.ServiceCategory", null)
                        .WithMany("ParentServiceCategories")
                        .HasForeignKey("ServiceCategoryId");
                });

            modelBuilder.Entity("MasterProfileServiceCategory", b =>
                {
                    b.HasOne("Domain.Entities.MasterProfile", null)
                        .WithMany()
                        .HasForeignKey("MasterProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ServiceCategory", null)
                        .WithMany()
                        .HasForeignKey("ServiceCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.MasterProfile", b =>
                {
                    b.Navigation("Masters")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ServiceCategory", b =>
                {
                    b.Navigation("ParentServiceCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
