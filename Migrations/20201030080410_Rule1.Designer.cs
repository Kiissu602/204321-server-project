﻿// <auto-generated />
using System;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibrarySystem.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201030080410_Rule1")]
    partial class Rule1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibrarySystem.Models.Book", b =>
                {
                    b.Property<string>("BookID")
                        .HasColumnType("char(10)");

                    b.Property<string>("BookImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<string>("BookTypeTypeID")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<int>("NumPage")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("PrintEdit")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Writer")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime>("YearPublic")
                        .HasColumnType("datetime2");

                    b.HasKey("BookID");

                    b.HasIndex("BookName");

                    b.HasIndex("BookTypeTypeID");

                    b.HasIndex("Writer");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("LibrarySystem.Models.BookType", b =>
                {
                    b.Property<string>("TypeID")
                        .HasColumnType("char(10)");

                    b.Property<string>("TypeBook")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("TypeID");

                    b.ToTable("BookType");
                });

            modelBuilder.Entity("LibrarySystem.Models.Borrow", b =>
                {
                    b.Property<int>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookID")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<DateTime>("BorrowDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Fines")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<string>("UserPID")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.HasKey("BorrowId");

                    b.HasIndex("BookID");

                    b.HasIndex("UserPID");

                    b.ToTable("Borrow");
                });

            modelBuilder.Entity("LibrarySystem.Models.Department", b =>
                {
                    b.Property<int>("Dnum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacultyFnum")
                        .HasColumnType("int");

                    b.HasKey("Dnum");

                    b.HasIndex("FacultyFnum");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("LibrarySystem.Models.Faculty", b =>
                {
                    b.Property<int>("Fnum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Fnum");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("LibrarySystem.Models.Rule", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("char(10)");

                    b.Property<int>("BookAmount")
                        .HasColumnType("int");

                    b.Property<int>("LimitDay")
                        .HasColumnType("int");

                    b.HasKey("Type");

                    b.ToTable("Rule");
                });

            modelBuilder.Entity("LibrarySystem.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("LibrarySystem.Models.User", b =>
                {
                    b.Property<string>("PID")
                        .HasColumnType("char(10)");

                    b.Property<DateTime>("Bdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentDnum")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(896)");

                    b.Property<int>("FacultyFnum")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("char(7)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.HasKey("PID");

                    b.HasIndex("DepartmentDnum");

                    b.HasIndex("FacultyFnum");

                    b.HasIndex("Type");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("LibrarySystem.Models.Book", b =>
                {
                    b.HasOne("LibrarySystem.Models.BookType", "BookType")
                        .WithMany("Booklist")
                        .HasForeignKey("BookTypeTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibrarySystem.Models.Borrow", b =>
                {
                    b.HasOne("LibrarySystem.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibrarySystem.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserPID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibrarySystem.Models.Department", b =>
                {
                    b.HasOne("LibrarySystem.Models.Faculty", "Faculty")
                        .WithMany("Departmentlist")
                        .HasForeignKey("FacultyFnum");
                });

            modelBuilder.Entity("LibrarySystem.Models.User", b =>
                {
                    b.HasOne("LibrarySystem.Models.Department", "Department")
                        .WithMany("Userlist")
                        .HasForeignKey("DepartmentDnum");

                    b.HasOne("LibrarySystem.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyFnum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
