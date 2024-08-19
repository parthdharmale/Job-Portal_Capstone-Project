﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineJobPortal.Data;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobPortalModels.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("AdminName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationID"));

                    b.Property<int>("CID")
                        .HasColumnType("int");

                    b.Property<int?>("CandidateCID")
                        .HasColumnType("int");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfApplication")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationID");

                    b.HasIndex("CandidateCID");

                    b.HasIndex("CityID");

                    b.HasIndex("JobID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Candidate", b =>
                {
                    b.Property<int>("CID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("DOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationPassoutYear1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationPassoutYear2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationPassoutYear3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("EducationResult1")
                        .HasColumnType("real");

                    b.Property<float>("EducationResult2")
                        .HasColumnType("real");

                    b.Property<float>("EducationResult3")
                        .HasColumnType("real");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateID")
                        .HasColumnType("int");

                    b.Property<string>("Workex1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Workex2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Workex3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkexDesc1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkexDesc2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkexDesc3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CID");

                    b.HasIndex("CityID");

                    b.HasIndex("CountryID");

                    b.HasIndex("StateID");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityID"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StateID")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.HasIndex("StateID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryID"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JobExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("JobPostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModeOfWork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RID")
                        .HasColumnType("int");

                    b.Property<string>("RecruiterContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecruiterEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecruiterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecruiterRID")
                        .HasColumnType("int");

                    b.Property<string>("Skills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobID");

                    b.HasIndex("RecruiterRID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Recruiter", b =>
                {
                    b.Property<int>("RID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("RID");

                    b.HasIndex("CityID");

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateID"));

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StateID");

                    b.HasIndex("CountryID");

                    b.ToTable("States");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Application", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.Candidate", null)
                        .WithMany("Applications")
                        .HasForeignKey("CandidateCID");

                    b.HasOne("OnlineJobPortal.Models.City", null)
                        .WithMany("Applications")
                        .HasForeignKey("CityID");

                    b.HasOne("OnlineJobPortal.Models.Job", null)
                        .WithMany("Applications")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Candidate", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.City", "City")
                        .WithMany("Candidates")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineJobPortal.Models.Country", "Country")
                        .WithMany("Candidates")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineJobPortal.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.City", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Job", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.Recruiter", null)
                        .WithMany("Jobs")
                        .HasForeignKey("RecruiterRID");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Recruiter", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.City", null)
                        .WithMany("Recruiters")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineJobPortal.Models.State", b =>
                {
                    b.HasOne("OnlineJobPortal.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Candidate", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.City", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Candidates");

                    b.Navigation("Recruiters");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Country", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("States");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Job", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.Recruiter", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("OnlineJobPortal.Models.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
