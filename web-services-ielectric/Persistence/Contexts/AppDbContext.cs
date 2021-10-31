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
        public DbSet<Appliance> Appliances { get; set; }

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
            builder.Entity<Appliance>().ToTable("Appliances");
            builder.Entity<Appliance>().HasKey(a => a.Id);
            builder.Entity<Appliance>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appliance>().Property(a => a.ClientId).IsRequired();
            builder.Entity<Appliance>().Property(a => a.ApplianceModelId).IsRequired();
            builder.Entity<Appliance>().Property(a => a.PurchaseDate).IsRequired();

            builder.Entity<Appliance>().HasData(
                new Appliance {Id=1,ClientId = 1,ApplianceModelId = 1,PurchaseDate = 2019}
            );
            
            // END APPLIANCE //

            // Apply Snake Case Naming Convention to All Objects
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
