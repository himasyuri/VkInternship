﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VkInternship.Models;

#nullable disable

namespace VkInternship.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VkInternship.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("integer")
                        .HasColumnName("user_group_id");

                    b.Property<int>("UserStateId")
                        .HasColumnType("integer")
                        .HasColumnName("user_state_id");

                    b.HasKey("Id");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("UserStateId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("VkInternship.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("user_groups", (string)null);
                });

            modelBuilder.Entity("VkInternship.Models.UserState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("user_states", (string)null);
                });

            modelBuilder.Entity("VkInternship.Models.User", b =>
                {
                    b.HasOne("VkInternship.Models.UserGroup", "UserGroup")
                        .WithMany()
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VkInternship.Models.UserState", "UserState")
                        .WithMany()
                        .HasForeignKey("UserStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");

                    b.Navigation("UserState");
                });
#pragma warning restore 612, 618
        }
    }
}
