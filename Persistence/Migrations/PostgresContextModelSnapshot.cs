﻿// <auto-generated />
using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;
using Persistence;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.ClassEnrollment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("classenrollment_pk");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.HasIndex(new[] { "Id" }, "classenrollment_id_uindex")
                        .IsUnique();

                    b.ToTable("ClassEnrollment", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<NpgsqlRange<DateOnly>?>("EnrolmentDateRange")
                        .HasColumnType("daterange");

                    b.Property<int?>("MaxStudentsNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("courses_pk");

                    b.HasIndex(new[] { "Name" }, "courses_\"name\"_uindex")
                        .IsUnique();

                    b.HasIndex(new[] { "Id" }, "courses_id_uindex")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("roles_pk");

                    b.HasIndex(new[] { "Id" }, "roles_\"id\"_uindex")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "roles_\"name\"_uindex")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entities.SessionTime", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("sessiontime_pk");

                    b.HasIndex(new[] { "Id" }, "sessiontime_id_uindex")
                        .IsUnique();

                    b.ToTable("SessionTime", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TeacherPerCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('\"Class_Id_seq\"'::regclass)");

                    b.Property<long>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('\"Class_CourseId_seq\"'::regclass)");

                    b.Property<long>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('\"Class_TeacherId_seq\"'::regclass)");

                    b.HasKey("Id")
                        .HasName("class_pk");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.HasIndex(new[] { "Id" }, "class_id_uindex")
                        .IsUnique();

                    b.ToTable("TeacherPerCourse", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TeacherPerCoursePerSessionTime", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('\"ClassSessions_Id_seq\"'::regclass)");

                    b.Property<long>("SessionTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('\"ClassSessions_SessionTimeId_seq\"'::regclass)");

                    b.Property<long>("TeacherPerCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('\"ClassSessions_ClassId_seq\"'::regclass)");

                    b.HasKey("Id")
                        .HasName("classsessions_pk");

                    b.HasIndex("SessionTimeId");

                    b.HasIndex("TeacherPerCourseId");

                    b.HasIndex(new[] { "Id" }, "classsessions_id_uindex")
                        .IsUnique();

                    b.ToTable("TeacherPerCoursePerSessionTime", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("nextval('\"Users_id_seq\"'::regclass)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FireBaseId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying");

                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("users_pk");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "Email" }, "users_\"email\"_uindex")
                        .IsUnique();

                    b.HasIndex(new[] { "Id" }, "users_\"id\"_uindex")
                        .IsUnique();

                    b.HasIndex(new[] { "FireBaseId" }, "users_\"keycloackid\"_uindex")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.ClassEnrollment", b =>
                {
                    b.HasOne("Domain.Entities.TeacherPerCourse", "Class")
                        .WithMany("ClassEnrollments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("classenrollment_class_id_fk");

                    b.HasOne("Domain.Entities.User", "Student")
                        .WithMany("ClassEnrollments")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("classenrollment_users_id_fk");

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.Entities.TeacherPerCourse", b =>
                {
                    b.HasOne("Domain.Entities.Course", "Course")
                        .WithMany("TeacherPerCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("class_course_id_fk");

                    b.HasOne("Domain.Entities.User", "Teacher")
                        .WithMany("TeacherPerCourses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("class_teacher_id_fk");

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Domain.Entities.TeacherPerCoursePerSessionTime", b =>
                {
                    b.HasOne("Domain.Entities.SessionTime", "SessionTime")
                        .WithMany("TeacherPerCoursePerSessionTimes")
                        .HasForeignKey("SessionTimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("classsessions_sessiontime_id_fk");

                    b.HasOne("Domain.Entities.TeacherPerCourse", "TeacherPerCourse")
                        .WithMany("TeacherPerCoursePerSessionTimes")
                        .HasForeignKey("TeacherPerCourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("classsessions_class_id_fk");

                    b.Navigation("SessionTime");

                    b.Navigation("TeacherPerCourse");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("users_role_id_fk");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Navigation("TeacherPerCourses");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.SessionTime", b =>
                {
                    b.Navigation("TeacherPerCoursePerSessionTimes");
                });

            modelBuilder.Entity("Domain.Entities.TeacherPerCourse", b =>
                {
                    b.Navigation("ClassEnrollments");

                    b.Navigation("TeacherPerCoursePerSessionTimes");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("ClassEnrollments");

                    b.Navigation("TeacherPerCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
