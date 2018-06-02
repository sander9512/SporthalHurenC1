using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SporthalHuren.Models;

namespace SporthalHuren.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180107043710_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SporthalHuren.Models.Activity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("RequiredCapacity");

                    b.HasKey("ID");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("SporthalHuren.Models.Domain.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActivityID");

                    b.Property<int>("Approved");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("HallID");

                    b.Property<int>("RemainingCapacity");

                    b.Property<int?>("RoomID");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("ActivityID");

                    b.HasIndex("HallID");

                    b.HasIndex("RoomID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("SporthalHuren.Models.Domain.SportsHallsActivity", b =>
                {
                    b.Property<int>("ActivityID");

                    b.Property<int>("SportsHallID");

                    b.HasKey("ActivityID", "SportsHallID");

                    b.HasIndex("SportsHallID");

                    b.ToTable("SportsHallsActivity");
                });

            modelBuilder.Entity("SporthalHuren.Models.Domain.SportsHallsFacility", b =>
                {
                    b.Property<int>("FacilityID");

                    b.Property<int>("SportsHallID");

                    b.HasKey("FacilityID", "SportsHallID");

                    b.HasIndex("SportsHallID");

                    b.ToTable("SportsHallsFacility");
                });

            modelBuilder.Entity("SporthalHuren.Models.Facility", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("SporthalHuren.Models.OpeningTime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Day")
                        .IsRequired();

                    b.Property<int>("HallID");

                    b.Property<string>("TimeClose")
                        .IsRequired();

                    b.Property<string>("TimeOpen")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("HallID");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("SporthalHuren.Models.Proprietor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("HouseNumber")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("StreetName")
                        .IsRequired();

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Proprietors");
                });

            modelBuilder.Entity("SporthalHuren.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<int>("HallID");

                    b.Property<string>("RoomNumber")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("HallID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("SporthalHuren.Models.SportsHall", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("HouseNumber")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<int>("ProprietorID");

                    b.Property<string>("StreetName")
                        .IsRequired();

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ProprietorID");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("SporthalHuren.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("HouseNumber")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("StreetName")
                        .IsRequired();

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SporthalHuren.Models.Domain.Booking", b =>
                {
                    b.HasOne("SporthalHuren.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityID");

                    b.HasOne("SporthalHuren.Models.SportsHall", "Hall")
                        .WithMany()
                        .HasForeignKey("HallID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SporthalHuren.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("SporthalHuren.Models.Domain.SportsHallsActivity", b =>
                {
                    b.HasOne("SporthalHuren.Models.Activity", "Activity")
                        .WithMany("SportsHallsActivities")
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SporthalHuren.Models.SportsHall", "Hall")
                        .WithMany("SportsHallActivities")
                        .HasForeignKey("SportsHallID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SporthalHuren.Models.Domain.SportsHallsFacility", b =>
                {
                    b.HasOne("SporthalHuren.Models.Facility", "Facility")
                        .WithMany("SportsHallFacilities")
                        .HasForeignKey("FacilityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SporthalHuren.Models.SportsHall", "Hall")
                        .WithMany("SportsHallFacilities")
                        .HasForeignKey("SportsHallID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SporthalHuren.Models.OpeningTime", b =>
                {
                    b.HasOne("SporthalHuren.Models.SportsHall", "Hall")
                        .WithMany("Times")
                        .HasForeignKey("HallID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SporthalHuren.Models.Room", b =>
                {
                    b.HasOne("SporthalHuren.Models.SportsHall", "Hall")
                        .WithMany("Rooms")
                        .HasForeignKey("HallID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SporthalHuren.Models.SportsHall", b =>
                {
                    b.HasOne("SporthalHuren.Models.Proprietor", "Proprietor")
                        .WithMany("Halls")
                        .HasForeignKey("ProprietorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
