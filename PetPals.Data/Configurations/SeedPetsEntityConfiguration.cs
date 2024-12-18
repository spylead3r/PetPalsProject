using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Data.Models;

namespace PetPals.Data.Configurations
{
    public class SeedPetsEntityConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasData(this.GeneratePets());
        }

        private Pet[] GeneratePets()
        {
            return new Pet[]
            {
                new Pet
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Buddy",
                    Species = "Dog",
                    Breed = "Golden Retriever",
                    Age = 3,
                    HealthStatus = "Healthy",
                    AdoptionStatus = "Available",
                    AdoptionFee = 250.00m
                },
                new Pet
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Bella",
                    Species = "Cat",
                    Breed = "Siamese",
                    Age = 4,
                    HealthStatus = "Healthy",
                    AdoptionStatus = "Available",
                    AdoptionFee = 150.00m
                },
                new Pet
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Charlie",
                    Species = "Dog",
                    Breed = "Beagle",
                    Age = 5,
                    HealthStatus = "Healthy",
                    AdoptionStatus = "Available",
                    AdoptionFee = 180.00m
                },
                new Pet
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Luna",
                    Species = "Cat",
                    Breed = "Maine Coon",
                    Age = 3,
                    HealthStatus = "Healthy",
                    AdoptionStatus = "Available",
                    AdoptionFee = 200.00m
                },
                new Pet
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Name = "Rocky",
                    Species = "Dog",
                    Breed = "Bulldog",
                    Age = 4,
                    HealthStatus = "Healthy",
                    AdoptionStatus = "Adopted",
                    AdoptionFee = 220.00m
                },
                new Pet
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    Name = "Molly",
                    Species = "Cat",
                    Breed = "Persian",
                    Age = 2,
                    HealthStatus = "Healthy",
                    AdoptionStatus = "Available",
                    AdoptionFee = 180.00m
                },
                new Pet
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    Name = "Simba",
                    Species = "Cat",
                    Breed = "Bengal",
                    Age = 5,
                    HealthStatus = "Healthy",
                    AdoptionStatus = "Available",
                    AdoptionFee = 230.00m
                },
                new Pet
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    Name = "Jake",
                    Species = "Dog",
                    Breed = "Husky",
                    Age = 2,
                    HealthStatus = "Healthy",
                    AdoptionStatus = "Available",
                    AdoptionFee = 270.00m
                }
            };
        }
    }
}
