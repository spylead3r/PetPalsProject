using Microsoft.EntityFrameworkCore;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.ViewModels.Volunteer;


namespace PetPals.Services.Data
{
    public class VolunteerService : IVolunteerService
    {
        private readonly PetPalsDbContext dbContext;

        public VolunteerService(PetPalsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }





        public async Task<List<VolunteerViewModel>> GetAllVolunteersAsync()
        {
            return await dbContext.Volunteers
                .Select(v => new VolunteerViewModel
                {
                    Id = v.Id,
                    Name = v.Name,
                    ContactInfo = v.ContactInfo,
                    Task = v.Task,
                    StartDate = v.StartDate,
                    EndDate = v.EndDate
                })
                .ToListAsync();
        }

        // Get a specific volunteer by ID
        public async Task<VolunteerFormModel?> GetVolunteerByIdAsync(Guid id)
        {
            var volunteer = await dbContext.Volunteers.FindAsync(id);
            if (volunteer == null) return null;

            return new VolunteerFormModel
            {
                Name = volunteer.Name,
                ContactInfo = volunteer.ContactInfo,
                Task = volunteer.Task,
                StartDate = volunteer.StartDate,
                EndDate = volunteer.EndDate
            };
        }

        // Add a new volunteer
        public async Task AddVolunteerAsync(VolunteerFormModel model)
        {
            var volunteer = new Volunteer
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                ContactInfo = model.ContactInfo,
                Task = model.Task,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            dbContext.Volunteers.Add(volunteer);
            await dbContext.SaveChangesAsync();
        }

        // Update an existing volunteer
        public async Task<bool> UpdateVolunteerAsync(Guid id, VolunteerFormModel model)
        {
            var volunteer = await dbContext.Volunteers.FindAsync(id);
            if (volunteer == null)
            {
                return false; // Volunteer not found
            }

            // Update the properties
            volunteer.Name = model.Name;
            volunteer.ContactInfo = model.ContactInfo;
            volunteer.Task = model.Task;
            volunteer.StartDate = model.StartDate;
            volunteer.EndDate = model.EndDate;

            await dbContext.SaveChangesAsync(); // Save changes to the database

            return true; // Successfully updated
        }


        // Delete a volunteer
        public async Task<bool> DeleteVolunteerAsync(Guid id)
        {
            var volunteer = await dbContext.Volunteers.FindAsync(id);
            if (volunteer == null)
            {
                return false;
            }

            dbContext.Volunteers.Remove(volunteer);
            await dbContext.SaveChangesAsync();
            return true;
        }

    }
}
