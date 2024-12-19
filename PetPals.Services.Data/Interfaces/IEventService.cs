using PetPals.Data.Models;
using PetPals.Web.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Services.Data.Interfaces
{
    public interface IEventService
    {
        Task CreateEventAsync(EventFormModel model);
        Task<Event> GetEventByIdAsync(int id);
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task UpdateEventAsync(int id, EventFormModel model);
        Task DeleteEventAsync(int id);

        Task AssignVolunteerAsync(int eventId, Guid volunteerId);
        Task RemoveVolunteerAsync(int eventId, Guid volunteerId);
        Task<IEnumerable<Volunteer>> GetVolunteersForEventAsync(int eventId);


    }
}
