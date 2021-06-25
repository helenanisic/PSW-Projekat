﻿// <auto-generated />
using System;
using MQuince.Repository.SQL.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MQuince.Repository.SQL.Migrations
{
    [DbContext(typeof(MQuinceDbContext))]
    partial class MQuinceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.AdressPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Appointments.AppointmentPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.FeedbackPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<Guid>("PatientId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Published")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.UserPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Banned")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserPersistence");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.CityPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PostNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.CountryPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.SpecializationPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.DoctorPersistence", b =>
                {
                    b.HasBaseType("MQuince.Repository.SQL.PersistenceEntities.UserPersistence");

                    b.Property<Guid>("SpecializationId")
                        .HasColumnType("char(36)");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctor");

                    b.HasDiscriminator().HasValue("DoctorPersistence");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.PatientPersistence", b =>
                {
                    b.HasBaseType("MQuince.Repository.SQL.PersistenceEntities.UserPersistence");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ChosenDoctorId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Jmbg")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Lbo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("MissedAppointments")
                        .HasColumnType("int");

                    b.Property<Guid>("ResidenceId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasIndex("ChosenDoctorId");

                    b.HasIndex("ResidenceId");

                    b.ToTable("Patient");

                    b.HasDiscriminator().HasValue("PatientPersistence");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.AdressPersistence", b =>
                {
                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.CityPersistence", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Appointments.AppointmentPersistence", b =>
                {
                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.DoctorPersistence", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.PatientPersistence", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.FeedbackPersistence", b =>
                {
                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.PatientPersistence", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.CityPersistence", b =>
                {
                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.CountryPersistence", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.DoctorPersistence", b =>
                {
                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.SpecializationPersistence", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.PatientPersistence", b =>
                {
                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.DoctorPersistence", "ChosenDoctor")
                        .WithMany()
                        .HasForeignKey("ChosenDoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.AdressPersistence", "Residence")
                        .WithMany()
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
