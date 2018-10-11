﻿// <auto-generated />
using System;
using CoreCourse.EFBasics.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreCourse.EFBasics.Web.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreCourse.EFBasics.Web.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("LecturerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.ToTable("Courses");

                    b.HasData(
                        new { Id = new Guid("11111111-1111-1111-1111-111111111111"), LecturerId = 1L, Name = "Programming C#" },
                        new { Id = new Guid("22222222-2222-2222-2222-222222222222"), LecturerId = 2L, Name = "Elementary Database Design" },
                        new { Id = new Guid("33333333-3333-3333-3333-333333333333"), LecturerId = 1L, Name = "ASP.NET Core" }
                    );
                });

            modelBuilder.Entity("CoreCourse.EFBasics.Web.Entities.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal?>("Scholarship");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new { Id = 1L, Birthdate = new DateTime(2001, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Marty Pants" },
                        new { Id = 2L, Birthdate = new DateTime(1998, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Chris Mahs", Scholarship = 1200m },
                        new { Id = 3L, Birthdate = new DateTime(1997, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Ann A. Fabettick", Scholarship = 600m },
                        new { Id = 4L, Birthdate = new DateTime(1999, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Will Szeedt" }
                    );
                });

            modelBuilder.Entity("CoreCourse.EFBasics.Web.Entities.StudentCourse", b =>
                {
                    b.Property<long>("StudentId");

                    b.Property<Guid>("CourseId");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new { StudentId = 1L, CourseId = new Guid("11111111-1111-1111-1111-111111111111") },
                        new { StudentId = 1L, CourseId = new Guid("33333333-3333-3333-3333-333333333333") },
                        new { StudentId = 2L, CourseId = new Guid("11111111-1111-1111-1111-111111111111") },
                        new { StudentId = 2L, CourseId = new Guid("22222222-2222-2222-2222-222222222222") },
                        new { StudentId = 2L, CourseId = new Guid("33333333-3333-3333-3333-333333333333") },
                        new { StudentId = 4L, CourseId = new Guid("22222222-2222-2222-2222-222222222222") },
                        new { StudentId = 4L, CourseId = new Guid("33333333-3333-3333-3333-333333333333") }
                    );
                });

            modelBuilder.Entity("CoreCourse.EFBasics.Web.Entities.StudentInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(30);

                    b.Property<long>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentInfo");

                    b.HasData(
                        new { Id = 100L, Email = "martypants@school.example", StudentId = 1L },
                        new { Id = 101L, Email = "chrismahs@school.example", Phone = "111 11 11 11", StudentId = 2L },
                        new { Id = 102L, Email = "annaf@school.example", Phone = "222 22 22 22", StudentId = 3L },
                        new { Id = 103L, Email = "willszeedt@school.example", StudentId = 4L }
                    );
                });

            modelBuilder.Entity("CoreCourse.EFBasics.Web.Entities.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal?>("YearlyWage");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new { Id = 1L, Name = "Mr. Ned Farious", YearlyWage = 27150m },
                        new { Id = 2L, Name = "Mrs. Alley Hope", YearlyWage = 31520m }
                    );
                });

            modelBuilder.Entity("CoreCourse.EFBasics.Web.Entities.Course", b =>
                {
                    b.HasOne("CoreCourse.EFBasics.Web.Entities.Teacher", "Lecturer")
                        .WithMany("Courses")
                        .HasForeignKey("LecturerId");
                });

            modelBuilder.Entity("CoreCourse.EFBasics.Web.Entities.StudentCourse", b =>
                {
                    b.HasOne("CoreCourse.EFBasics.Web.Entities.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreCourse.EFBasics.Web.Entities.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreCourse.EFBasics.Web.Entities.StudentInfo", b =>
                {
                    b.HasOne("CoreCourse.EFBasics.Web.Entities.Student", "Student")
                        .WithOne("ContactInfo")
                        .HasForeignKey("CoreCourse.EFBasics.Web.Entities.StudentInfo", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
