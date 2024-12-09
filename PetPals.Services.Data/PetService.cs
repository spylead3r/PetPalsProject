using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;



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
            return await dbContext.Pets.ToListAsync(); // Fetch all pets from the database
        }





        public async Task<Pet?> GetPetByIdAsync(Guid id)
        {
            return await dbContext.Pets.FindAsync(id);
        }

        public async Task AddPetAsync(PetFormModel formModel)
        {
            Pet pet = new Pet()
            {
                Name = formModel.Name,
                Species = formModel.Species,
                Breed = formModel.Breed,
                Age = formModel.Age,
                HealthStatus = formModel.HealthStatus,
                AdoptionStatus = formModel.AdoptionStatus,
                PhotoPath = formModel.PhotoPath,
            };

            await dbContext.Pets.AddAsync(pet);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            dbContext.Pets.Update(pet);
            await dbContext.SaveChangesAsync();
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


    }

}
