﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TestTaskNikonov.Models;

namespace TestTaskNikonov.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20171211124527_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestTaskNikonov.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryID");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Size");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("TestTaskNikonov.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TestTaskNikonov.Models.Change", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicationId");

                    b.Property<DateTime>("DateChange");

                    b.Property<string>("Description");

                    b.Property<int?>("IdApplication");

                    b.Property<int>("IdUser");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("UserId");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("TestTaskNikonov.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("SureName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestTaskNikonov.Models.Application", b =>
                {
                    b.HasOne("TestTaskNikonov.Models.Category", "Category")
                        .WithMany("Applications")
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("TestTaskNikonov.Models.Change", b =>
                {
                    b.HasOne("TestTaskNikonov.Models.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId");

                    b.HasOne("TestTaskNikonov.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
