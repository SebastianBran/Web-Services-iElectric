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
        public DbSet<ApplianceModel> ApplianceModels { get; set; }
        public DbSet<ApplianceBrand> ApplianceBrands { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

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

            //Example data
            /*builder.Entity<Client>().HasData(
                new Client { Id = 1, Names = "Estefano Sebastian", LastNames = "Bran Zapata", Address = "Los Angeles", CellphoneNumber = 987899219, Email = "sebas@gmail.com", Password = "Sebas123" }
            );*/

            // END CLIENT //

            // START TECHNICIAN //

            //Constraints
            builder.Entity<Technician>().ToTable("Technicians");

            builder.Entity<Technician>().HasData(
                new Technician { Id = 1, Names = "Estefano Sebastian", LastNames = "Bran Zapata", Address = "Los Angeles", CellphoneNumber = 987899219, Email = "sebas@gmail.com", Password = "Sebas123" }
            );

            // END TECHNICIAN //
            
            // START APPLIANCE //
            
            //Constraints
            builder.Entity<ApplianceModel>().ToTable("ApplianceModels");
            builder.Entity<ApplianceModel>().HasKey(a => a.Id);
            builder.Entity<ApplianceModel>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ApplianceModel>().Property(a => a.Name).IsRequired();
            builder.Entity<ApplianceModel>().Property(a => a.Model).IsRequired();
            builder.Entity<ApplianceModel>().Property(a => a.ImgPath).IsRequired();
            builder.Entity<ApplianceModel>().Property(a => a.PurchaseDate).IsRequired();
            builder.Entity<ApplianceModel>().Property(a => a.ApplianceBrandId).IsRequired();
            builder.Entity<ApplianceModel>().Property(a => a.ClientId).IsRequired();

            builder.Entity<ApplianceModel>().HasData(
                new ApplianceModel {Id=1,Name = "",Model = "",ImgPath = "",PurchaseDate = "",ApplianceBrandId = 1,ClientId = 1}
            );
            
            // END APPLIANCE //
            // START BRAND //
            builder.Entity<ApplianceBrand>().ToTable("ApplianceBrands");
            builder.Entity<ApplianceBrand>().HasKey(a => a.Id);
            builder.Entity<ApplianceBrand>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ApplianceBrand>().Property(a => a.Name).IsRequired();
            builder.Entity<ApplianceBrand>().Property(a => a.ImgPath).IsRequired();
            // END BRAND//
            builder.Entity<ApplianceBrand>().HasMany(a => a.ApplianceModels)
                .WithOne(a => a.ApplianceBrand)
                .HasForeignKey(a => a.ApplianceBrandId);

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


            // Apply Snake Case Naming Convention to All Objects
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
