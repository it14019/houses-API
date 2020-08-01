using HouseAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseAPI.Persistance.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Resident> Residents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<House>().ToTable("Houses");
            builder.Entity<House>().HasKey(p => p.Id);
            builder.Entity<House>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<House>().Property(p => p.Number).IsRequired().HasMaxLength(2);
            builder.Entity<House>().Property(p => p.Street).IsRequired();
            builder.Entity<House>().Property(p => p.City).IsRequired();
            builder.Entity<House>().Property(p => p.Country).IsRequired();
            builder.Entity<House>().Property(p => p.PostCode).IsRequired().HasMaxLength(7);
            builder.Entity<House>().HasMany(p => p.Apartments).WithOne(p => p.House).HasForeignKey(p => p.HouseId);

            builder.Entity<House>().HasData
           (
               new House { 
                   Id = 1,
                   Number = 22, 
                   Street = "Zirgu Street", 
                   City = "Jelgava", 
                   Country = "Latvia", 
                   PostCode = "LV-3001" 
               },
               new House { 
                   Id = 2, 
                   Number = 19, 
                   Street = "Spridisu Street", 
                   City = "Dobele", 
                   Country = "Latvia", 
                   PostCode = "LV-3008" 
               }
           );

            builder.Entity<Apartment>().ToTable("Apartments");
            builder.Entity<Apartment>().HasKey(p => p.Id);
            builder.Entity<Apartment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Apartment>().Property(p => p.Number).IsRequired().HasMaxLength(3);
            builder.Entity<Apartment>().Property(p => p.Floor).IsRequired().HasMaxLength(2);
            builder.Entity<Apartment>().Property(p => p.Rooms).IsRequired().HasMaxLength(2);
            builder.Entity<Apartment>().Property(p => p.PropertySize).IsRequired();
            builder.Entity<Apartment>().Property(p => p.LivingArea).IsRequired();
            builder.Entity<Apartment>().HasMany(p => p.Residents).WithOne(p => p.Apartment).HasForeignKey(p => p.ApartmentId);

            builder.Entity<Apartment>().HasData
            (
                new Apartment
                {
                    Id = 1,
                    Number = 12,
                    Floor = 3,
                    Rooms = 2,
                    PropertySize = 80.3,
                    LivingArea = 70.4,
                    HouseId = 1
                },
                new Apartment
                {
                    Id = 2,
                    Number = 19,
                    Floor = 4,
                    Rooms = 3,
                    PropertySize = 103.86,
                    LivingArea = 98.2,
                    HouseId = 2
                }
            );

            builder.Entity<Resident>().ToTable("Residents");
            builder.Entity<Resident>().HasKey(p => p.Id);
            builder.Entity<Resident>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Resident>().Property(p => p.Name).IsRequired();
            builder.Entity<Resident>().Property(p => p.Surname).IsRequired();
            builder.Entity<Resident>().Property(p => p.PersonalCode).IsRequired().HasMaxLength(12);
            builder.Entity<Resident>().Property(p => p.BirthDate).IsRequired().HasMaxLength(8);
            builder.Entity<Resident>().Property(p => p.Phone).IsRequired().HasMaxLength(8);
            builder.Entity<Resident>().Property(p => p.Mail).IsRequired();

            builder.Entity<Resident>().HasData
          (
              new Resident
              {
                  Id = 1,
                  Name = "Krista",
                  Surname = "Awesome",
                  PersonalCode = "121295-10000",
                  BirthDate = "12-12-95",
                  Phone = 28222222,
                  Mail = "krista@awesome.com",
                  ApartmentId = 1
              },
              new Resident
              {
                  Id = 2,
                  Name = "Edgars",
                  Surname = "Awesome",
                  PersonalCode = "111194-20000",
                  BirthDate = "11-11-94",
                  Phone = 28211111,
                  Mail = "edgars@awesome.com",
                  ApartmentId = 2
              }
          );
        }
    }
}
