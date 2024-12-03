﻿// <auto-generated />
using System;
using Infrastructure.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persitence.Migrations
{
    [DbContext(typeof(ScheduleAppointmentContext))]
    [Migration("20240611065335_Add-LaboratoryResults")]
    partial class AddLaboratoryResults
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsultingRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAppointment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultingRoomId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("StatusId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.ConsultingRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ConsultingRooms");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("ConsultingRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsultingRoomId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.LaboratoryResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LaboratoryTestId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryTestId");

                    b.HasIndex("PatientId");

                    b.ToTable("LaboratoryResults");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.LaboratoryTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsultingRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ConsultingRoomId");

                    b.ToTable("LaboratoryTest");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.LaboryTestAppointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppoinmentId")
                        .HasColumnType("int");

                    b.Property<int>("LaboratoryTestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppoinmentId");

                    b.HasIndex("LaboratoryTestId");

                    b.ToTable("LaboryTestAppointment");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Allergy")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("ConsultingRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Smoke")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ConsultingRoomId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsultingRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ConsultingRoomId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("AgendaMedica.Core.Domain.Entities.ConsultingRoom", "ConsultingRoom")
                        .WithMany("Appointments")
                        .HasForeignKey("ConsultingRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgendaMedica.Core.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AgendaMedica.Core.Domain.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AgendaMedica.Core.Domain.Entities.Status", "Status")
                        .WithMany("Appointments")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsultingRoom");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("AgendaMedica.Core.Domain.Entities.ConsultingRoom", "ConsultingRoom")
                        .WithMany("Doctors")
                        .HasForeignKey("ConsultingRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsultingRoom");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.LaboratoryResult", b =>
                {
                    b.HasOne("AgendaMedica.Core.Domain.Entities.LaboratoryTest", "LaboratoryTest")
                        .WithMany("LaboratoryResults")
                        .HasForeignKey("LaboratoryTestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AgendaMedica.Core.Domain.Entities.Patient", "Patient")
                        .WithMany("LaboratoryResults")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LaboratoryTest");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.LaboratoryTest", b =>
                {
                    b.HasOne("AgendaMedica.Core.Domain.Entities.ConsultingRoom", "ConsultingRoom")
                        .WithMany("LaboratoryTests")
                        .HasForeignKey("ConsultingRoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ConsultingRoom");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.LaboryTestAppointment", b =>
                {
                    b.HasOne("AgendaMedica.Core.Domain.Entities.Appointment", "Appointment")
                        .WithMany("LaboryTestAppointments")
                        .HasForeignKey("AppoinmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AgendaMedica.Core.Domain.Entities.LaboratoryTest", "LaboratoryTest")
                        .WithMany("LaboryTestAppointments")
                        .HasForeignKey("LaboratoryTestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("LaboratoryTest");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Patient", b =>
                {
                    b.HasOne("AgendaMedica.Core.Domain.Entities.ConsultingRoom", "ConsultingRoom")
                        .WithMany("Patients")
                        .HasForeignKey("ConsultingRoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ConsultingRoom");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.User", b =>
                {
                    b.HasOne("AgendaMedica.Core.Domain.Entities.ConsultingRoom", "ConsultingRoom")
                        .WithMany("Users")
                        .HasForeignKey("ConsultingRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgendaMedica.Core.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsultingRoom");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Appointment", b =>
                {
                    b.Navigation("LaboryTestAppointments");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.ConsultingRoom", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Doctors");

                    b.Navigation("LaboratoryTests");

                    b.Navigation("Patients");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.LaboratoryTest", b =>
                {
                    b.Navigation("LaboratoryResults");

                    b.Navigation("LaboryTestAppointments");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("LaboratoryResults");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AgendaMedica.Core.Domain.Entities.Status", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
