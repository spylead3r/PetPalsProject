using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.ViewModels.Event;

namespace PetPals.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await eventService.GetAllEventsAsync();
            return View(events);
        }


        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View(new EventFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventFormModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await eventService.CreateEventAsync(model);
                    TempData["SuccessMessage"] = "Event created successfully!";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Failed to create the event. Error: {ex.Message}";
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignVolunteer(int eventId, Guid volunteerId)
        {
            try
            {
                await eventService.AssignVolunteerAsync(eventId, volunteerId);
                TempData["SuccessMessage"] = "Volunteer assigned successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to assign volunteer. Error: {ex.Message}";
            }

            return RedirectToAction("EventDetails", new { id = eventId });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await eventService.DeleteEventAsync(id); // Call the service to delete the event
                TempData["SuccessMessage"] = "Event deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to delete the event. Error: {ex.Message}";
            }

            return RedirectToAction("Index", "Home"); // Redirect back to the index view
        }


    }
}
