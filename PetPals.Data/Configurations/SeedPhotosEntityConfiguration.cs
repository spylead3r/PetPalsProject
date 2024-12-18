using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetPals.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Data.Configurations
{
    public class SeedPhotosEntityConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasData(this.GeneratePhotos());
        }

        private Photo[] GeneratePhotos()
        {
            return new Photo[]
            {
                // Photos for Buddy
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/buddy1.jpg", PetId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/buddy2.jpg", PetId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/buddy3.jpg", PetId = Guid.Parse("11111111-1111-1111-1111-111111111111") },

                // Photos for Bella
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/bella1.jpg", PetId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/bella2.jpg", PetId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/bella3.jpg", PetId = Guid.Parse("22222222-2222-2222-2222-222222222222") },

                // Photos for Charlie
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/charlie1.jpg", PetId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/charlie2.jpg", PetId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/charlie3.jpg", PetId = Guid.Parse("33333333-3333-3333-3333-333333333333") },

                // Photos for Luna
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna1.jpg", PetId = Guid.Parse("44444444-4444-4444-4444-444444444444") },
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna2.jpg", PetId = Guid.Parse("44444444-4444-4444-4444-444444444444") },
                new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna3.jpg", PetId = Guid.Parse("44444444-4444-4444-4444-444444444444") },

                // You can replicate this pattern for all other pets
                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna1.jpg", PetId = Guid.Parse("55555555-5555-5555-5555-555555555555") },
                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna2.jpg", PetId = Guid.Parse("55555555-5555-5555-5555-555555555555") },
                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna3.jpg", PetId = Guid.Parse("55555555-5555-5555-5555-555555555555") },

                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna1.jpg", PetId = Guid.Parse("66666666-6666-6666-6666-666666666666") },
                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna2.jpg", PetId = Guid.Parse("66666666-6666-6666-6666-666666666666") },
                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna3.jpg", PetId = Guid.Parse("66666666-6666-6666-6666-666666666666") },

                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna1.jpg", PetId = Guid.Parse("77777777-7777-7777-7777-777777777777") },
                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna2.jpg", PetId = Guid.Parse("77777777-7777-7777-7777-777777777777") },
                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna3.jpg", PetId = Guid.Parse("77777777-7777-7777-7777-777777777777") },

                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna1.jpg", PetId = Guid.Parse("88888888-8888-8888-8888-888888888888") },
                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna2.jpg", PetId = Guid.Parse("88888888-8888-8888-8888-888888888888") },
                //new Photo { Id = Guid.NewGuid(), PhotoPath = "uploads/luna3.jpg", PetId = Guid.Parse("88888888-8888-8888-8888-888888888888") },
            };
        }
    }
}
