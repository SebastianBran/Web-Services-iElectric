using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Models;
using web_services_ielectric.Extensions;

namespace web_services_ielectric.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // START PERSON //

            // Constraints
            builder.Entity<Person>().ToTable("Persons");
            builder.Entity<Person>().HasKey(p => p.Id);
            builder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Person>().Property(p => p.Names).IsRequired().HasMaxLength(30);
            builder.Entity<Person>().Property(p => p.LastNames).IsRequired().HasMaxLength(30);
            builder.Entity<Person>().Property(p => p.CellphoneNumber).IsRequired();
            builder.Entity<Person>().Property(p => p.Address).IsRequired().HasMaxLength(50);
            builder.Entity<Person>().Property(p => p.Email).IsRequired();
            builder.Entity<Person>().Property(p => p.Password).IsRequired();
            
            // END PERSON //

            // START CLIENT //

            // Constraints
            builder.Entity<Client>().ToTable("Clients");

            //Relationships
            builder.Entity<Client>().HasMany(p => p.Appointment)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId);

            //Example data
            /*builder.Entity<Client>().HasData(
                new Client { Id = 1, Names = "Estefano Sebastian", LastNames = "Bran Zapata", Address = "Los Angeles", CellphoneNumber = 987899219, Email = "sebas@gmail.com", Password = "Sebas123" }
            );*/

            // END CLIENT //

            // START TECHNICIAN //

            //Constraints
            builder.Entity<Technician>().ToTable("Technicians");

            //Relationships
            builder.Entity<Technician>().HasMany(p => p.Appointment)
                .WithOne(p => p.Technician)
                .HasForeignKey(p => p.TechnicianId);

            builder.Entity<Technician>().HasData(
                new Technician { Id = 1, Names = "Estefano Sebastian", LastNames = "Bran Zapata", Address = "Los Angeles", CellphoneNumber = 987899219, Email = "sebas@gmail.com", Password = "Sebas123" }
            );

            // END TECHNICIAN //

            // START ANNOUNCEMENT //

            builder.Entity<Announcement>().ToTable("Announcements");
            builder.Entity<Announcement>().HasKey(p => p.Id);
            builder.Entity<Announcement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Announcement>().Property(p => p.Title).IsRequired().HasMaxLength(30);
            builder.Entity<Announcement>().Property(p => p.Description).IsRequired();
            builder.Entity<Announcement>().Property(p => p.Content).IsRequired();
            builder.Entity<Announcement>().Property(p => p.UrlToImage).IsRequired();
            builder.Entity<Announcement>().Property(p => p.TypeOfAnnouncement).IsRequired();
            builder.Entity<Announcement>().Property(p => p.Visible).IsRequired();

            // END ANNOUNCEMENT //


            // START ANNOUNCEMENT //
            builder.Entity<Appointment>().ToTable("Appointments");
            builder.Entity<Appointment>().HasKey(p => p.Id);
            builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(p => p.DateReserve).IsRequired();
            builder.Entity<Appointment>().Property(p => p.Hour).IsRequired();
            // builder.Entity<Appointment>().Property(p => p.Done).IsRequired();

            builder.Entity<Appointment>().HasData(
                new Appointment { 
                    Id = 1, 
                    DateReserve = "10-12-2021",
                    DateAttention = "10-12-2021",
                    Hour = "15:00",
                    ClientId = 1,
                    Done = false
                }
            );
            // END ANNOUNCEMENT //


            // Apply Snake Case Naming Convention to All Objects
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
