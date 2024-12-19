using Microsoft.EntityFrameworkCore;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Web.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Services.Data.Interfaces
{
    public class EventService : IEventService
    {
        private readonly PetPalsDbContext dbContext;

        public EventService(PetPalsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AssignVolunteerAsync(int eventId, Guid volunteerId)
        {
            var eventEntity = await dbContext.Events
                .Include(e => e.Volunteers)
                .FirstOrDefaultAsync(e => e.Id == eventId);

            var volunteer = await dbContext.Volunteers.FirstOrDefaultAsync(v => v.Id == volunteerId);

            if (eventEntity == null || volunteer == null)
            {
                throw new InvalidOperationException("Event or Volunteer not found.");
            }

            if (eventEntity.Volunteers.Count >= eventEntity.MaxParticipants)
            {
                throw new InvalidOperationException("Cannot assign volunteer, max participants reached.");
            }

            eventEntity.Volunteers.Add(volunteer);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateEventAsync(EventFormModel model)
        {
            string photoPath = null;

            // Handle photo upload
            if (model.Photo != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/events");
                Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(fileStream);
                }

                photoPath = $"/uploads/events/{fileName}";
            }

            var newEvent = new Event
            {
                Title = model.Title,
                Description = model.Description,
                Date = model.Date,
                Location = model.Location,
                MaxParticipants = model.MaxParticipants,
                Volunteers = new List<Volunteer>(),
                PhotoPath = photoPath // Set the photo path

            };

            await dbContext.Events.AddAsync(newEvent);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventToDelete = await dbContext.Events.FindAsync(id);

            if (eventToDelete == null)
            {
                throw new Exception("Event not found.");
            }

            // Remove event
            dbContext.Events.Remove(eventToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await dbContext.Events
                .OrderBy(e => e.Date)
                .ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await dbContext.Events
                .Include(e => e.Volunteers) // Include related volunteers
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Volunteer>> GetVolunteersForEventAsync(int eventId)
        {
            var eventEntity = await dbContext.Events
                .Include(e => e.Volunteers) // Include related volunteers
                .FirstOrDefaultAsync(e => e.Id == eventId);

            if (eventEntity == null)
            {
                throw new InvalidOperationException("Event not found.");
            }

            return eventEntity.Volunteers;
        }


        public async Task RemoveVolunteerAsync(int eventId, Guid volunteerId)
        {
            var eventEntity = await dbContext.Events
                .Include(e => e.Volunteers) // Include related volunteers
                .FirstOrDefaultAsync(e => e.Id == eventId);

            if (eventEntity == null)
            {
                throw new InvalidOperationException("Event not found.");
            }

            var volunteer = eventEntity.Volunteers.FirstOrDefault(v => v.Id == volunteerId);

            if (volunteer == null)
            {
                throw new InvalidOperationException("Volunteer not assigned to this event.");
            }

            eventEntity.Volunteers.Remove(volunteer);
            await dbContext.SaveChangesAsync();
        }


        public async Task UpdateEventAsync(int id, EventFormModel model)
        {
            var eventEntity = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (eventEntity == null)
            {
                throw new InvalidOperationException("Event not found.");
            }

            // Update fields
            eventEntity.Title = model.Title;
            eventEntity.Description = model.Description;
            eventEntity.Date = model.Date;
            eventEntity.Location = model.Location;
            eventEntity.MaxParticipants = model.MaxParticipants;

            // Save changes
            await dbContext.SaveChangesAsync();
        }

    }
}
