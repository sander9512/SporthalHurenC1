using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SporthalHuren.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SporthalHuren.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Proprietor> Proprietors { get; set; }
        public DbSet<SportsHall> Halls { get; set; }
        public DbSet<OpeningTime> Times { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SportsHallsActivity> SportsHallsActivity { get; set; }
        public DbSet<SportsHallsFacility> SportsHallsFacility { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportsHallsActivity>()
                .HasKey(bc => new { bc.ActivityID, bc.SportsHallID });

            modelBuilder.Entity<SportsHallsActivity>()
                .HasOne(bc => bc.Activity)
                .WithMany(bc => bc.SportsHallsActivities)
                .HasForeignKey(bc => bc.ActivityID);

            modelBuilder.Entity<SportsHallsActivity>()
                .HasOne(bc => bc.Hall)
                .WithMany(bc => bc.SportsHallActivities)
                .HasForeignKey(bc => bc.SportsHallID);

            modelBuilder.Entity<SportsHallsFacility>()
                .HasKey(bc => new { bc.FacilityID, bc.SportsHallID });

            modelBuilder.Entity<SportsHallsFacility>()
                .HasOne(bc => bc.Facility)
                .WithMany(bc => bc.SportsHallFacilities)
                .HasForeignKey(bc => bc.FacilityID);

            modelBuilder.Entity<SportsHallsFacility>()
                .HasOne(bc => bc.Hall)
                .WithMany(bc => bc.SportsHallFacilities)
                .HasForeignKey(bc => bc.SportsHallID);

            modelBuilder.Entity<Booking>()
                .HasOne(x => x.Room)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            //modelBuilder.Entity<SportsHall>()
            //    .HasOne<Proprietor>(s => s.Proprietor)
            //    .WithMany(g => g.Halls)
            //    .HasForeignKey(s => s.ID);

        }
    }
}
