﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using desafio_cda.api.Repositories.Context;

#nullable disable

namespace desafio_cda.api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220308232011_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("desafio_cda.api.Models.CriminalCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CreateUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("createUserId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<decimal>("Penalty")
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("penalty");

                    b.Property<int>("PrisonTime")
                        .HasColumnType("integer")
                        .HasColumnName("prisonTime");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint")
                        .HasColumnName("statusId");

                    b.Property<long>("UpdateUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("updateUserId");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("criminalCodes");
                });

            modelBuilder.Entity("desafio_cda.api.Models.Status", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.ToTable("status");
                });

            modelBuilder.Entity("desafio_cda.api.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasColumnName("updatedAt");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("userName");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("desafio_cda.api.Models.CriminalCode", b =>
                {
                    b.HasOne("desafio_cda.api.Models.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("desafio_cda.api.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("desafio_cda.api.Models.User", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreateUser");

                    b.Navigation("Status");

                    b.Navigation("UpdateUser");
                });
#pragma warning restore 612, 618
        }
    }
}
