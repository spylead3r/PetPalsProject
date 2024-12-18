using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.ViewModels.Pet;
using static PetPals.Common.EntityValidationConstants;
using Pet = PetPals.Data.Models.Pet;



namespace PetPals.Services.Data
{
    public class PetService : IPetService
    {
        private readonly PetPalsDbContext dbContext;

        public PetService(PetPalsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await dbContext.Pets
                .Include(p => p.Photos)
                .ToListAsync(); 
        }

        public async Task<IEnumerable<PetIndexViewModel>> GetAllPetsWithPhotoAsync()
        {
            return await this.dbContext.Pets
                .Include(p => p.Photos)
                .Select(p => new PetIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Species = p.Species,
                    Breed = p.Breed,
                    Age = p.Age,
                    AdoptionStatus = p.AdoptionStatus,
                    PhotoPath = p.Photos.Any() ? p.Photos.First().PhotoPath : null
                })
                .ToListAsync();
        }


        public async Task<bool> UpdatePetWithPhotosAsync(Guid id, PetFormModel model)
        {
            var pet = await dbContext.Pets
                .Include(p => p.Photos) // Include photos collection
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                return false; // Entity not found
            }

            // Add photos if provided
            if (model.Photos != null && pet.Photos.Count + model.Photos.Count <= 3)
            {
                foreach (var photo in model.Photos)
                {
                    var filePath = await SavePhotoAsync(photo);

                    pet.Photos.Add(new Photo
                    {
                        Id = Guid.NewGuid(),  // Generate a unique ID for the photo
                        PhotoPath = filePath,  // Assign the saved file path
                        PetId = pet.Id        // Link the photo to the pet
                    });
                }
            }
            else if (model.Photos != null)
            {
                return false; // Exceeds photo limit
            }

            // Update other properties
            pet.Name = model.Name;
            pet.Age = model.Age;
            pet.Breed = model.Breed;

            // Save all changes in one transaction
            try
            {
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false; // Handle concurrency issues
            }
        }


        public async Task<bool> AddPetPhotosAsync(Guid petId, List<IFormFile> files)
        {
            // Fetch the Pet entity with its Photos collection
            var pet = await dbContext.Pets
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(p => p.Id == petId);

            if (pet == null)
            {
                return false; // Pet not found
            }

            if (pet.Photos.Count + files.Count > 3)
            {
                return false; // Prevent adding more than 3 images
            }

            // Add new photos to the Photos collection
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // Generate a unique file name for the photo
                    var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine("wwwroot/uploads", fileName);

                    // Save the file to the server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Add the new Photo to the Pet's Photos collection
                    var photo = new Photo
                    {
                        Id = Guid.NewGuid(),
                        PhotoPath = $"uploads/{fileName}",
                        PetId = petId
                    };

                    dbContext.Photos.Add(photo); // Explicitly add the new photo
                }
            }

            // Save changes
            await dbContext.SaveChangesAsync();

            return true;
        }





        public async Task<bool> UpdatePetPhotosAsync(Guid petId, List<IFormFile> files)
        {
            // Fetch the Pet and its Photos
            var pet = await dbContext.Pets
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(p => p.Id == petId);

            if (pet == null)
            {
                return false; // Pet not found
            }

            // Delete existing photos if new files are uploaded
            if (files != null && files.Count > 0)
            {
                // Remove old photos
                foreach (var existingPhoto in pet.Photos.ToList())
                {
                    dbContext.Photos.Remove(existingPhoto);
                }

                // Add new photos
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        var filePath = Path.Combine("wwwroot/uploads", fileName);

                        // Save the file
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Add new photo to the database
                        pet.Photos.Add(new Photo
                        {
                            Id = Guid.NewGuid(),
                            PhotoPath = $"uploads/{fileName}",
                            PetId = pet.Id
                        });
                    }
                }
            }

            // Save changes to the database
            await dbContext.SaveChangesAsync();
            return true;
        }




        public async Task<Guid?> DeletePhotoAsync(Guid photoId)
        {
            var photo = await dbContext.Photos.FindAsync(photoId);

            if (photo != null)
            {
                // Remove the file from disk
                var filePath = Path.Combine("wwwroot", photo.PhotoPath);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Store the PetId before removing the photo
                var petId = photo.PetId;



                // Remove the photo from the database
                dbContext.Photos.Remove(photo);
                await dbContext.SaveChangesAsync();

                return petId; // Return the associated PetId
            }

            return null; // Photo not found
        }



        public async Task<Pet?> GetPetByIdAsync(Guid id)
        {
            return await this.dbContext.Pets
        .Include(p => p.Photos)
        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPetAsync(PetFormModel model)
        {
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Species = model.Species,
                Breed = model.Breed,
                Age = model.Age,
                HealthStatus = model.HealthStatus,
                AdoptionStatus = model.AdoptionStatus,
                AdoptionFee = model.AdoptionFee,
                Photos = new List<Photo>() // Initialize the photos list
            };

            // Process and add uploaded photos to the Pet entity
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (var photo in model.Photos)
                {
                    if (photo.Length > 0) // Ensure the file is not empty
                    {
                        var filePath = await SavePhotoAsync(photo); // Save photo to the uploads folder
                        pet.Photos.Add(new Photo
                        {
                            Id = Guid.NewGuid(),
                            PhotoPath = $"uploads/{filePath}", // Adjust the path as needed
                            PetId = pet.Id
                        });
                    }
                }
            }

            // Add the Pet entity (including its Photos) to the database
            await dbContext.Pets.AddAsync(pet);
            await dbContext.SaveChangesAsync(); // Save all changes at once
        }


        public async Task UpdatePetAsync(Pet pet)
        {
            dbContext.Pets.Update(pet);
            await dbContext.SaveChangesAsync();
        }

        public async Task<PetDetailsViewModel?> GetPetDetailsAsync(Guid id)
        {
            return await this.dbContext.Pets
                .Include(p => p.Photos)
                .Where(p => p.Id == id)
                .Select(p => new PetDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Species = p.Species,
                    Breed = p.Breed,
                    Age = p.Age,
                    HealthStatus = p.HealthStatus,
                    AdoptionStatus = p.AdoptionStatus,
                    Photos = p.Photos.ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdatePetAsync(Guid id, PetFormModel model)
        {
            var pet = await this.GetPetByIdAsync(id);

            if (pet == null)
            {
                return false;
            }

            // Update the pet's properties.
            pet.Name = model.Name;
            pet.Species = model.Species;
            pet.Breed = model.Breed;
            pet.Age = model.Age;
            pet.HealthStatus = model.HealthStatus;
            pet.AdoptionStatus = model.AdoptionStatus;

            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (var photo in model.Photos)
                {
                    if (photo.Length > 0)
                    {
                        // Generate a unique file path
                        var fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                        var filePath = Path.Combine("wwwroot/uploads", fileName);

                        // Save the file to the server
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await photo.CopyToAsync(stream);
                        }

                        // Add the new photo to the pet's Photos collection
                        pet.Photos.Add(new Photo
                        {
                            Id = Guid.NewGuid(),
                            PhotoPath = $"uploads/{fileName}",
                            PetId = pet.Id
                        });
                    }
                }
            }

            // Save changes to the database
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeletePetAsync(Guid id)
        {
            var pet = await dbContext.Pets.FindAsync(id);
            if (pet != null)
            {
                dbContext.Pets.Remove(pet);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetTotalPetsCountAsync(string search)
        {
            var query = dbContext.Pets.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search) || p.Species.Contains(search));
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<Pet>> GetCatsAsync()
        {
            return await this.dbContext.Pets
                .Where(p => p.Species.ToLower() == "cat")
                .ToListAsync();
        }




        private async Task<string> SavePhotoAsync(IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                throw new ArgumentException("Invalid photo file.");
            }

            // Define the upload path
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate unique file name
            var uniqueFileName = $"{Guid.NewGuid()}_{photo.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Save file to disk
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            // Return relative file path for storage
            return $"{uniqueFileName}";
        }


    }

}
