using Microsoft.AspNetCore.Mvc;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.ViewModels.Volunteer;



namespace PetPals.Web.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IVolunteerService volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            this.volunteerService = volunteerService;
        }

        // List all volunteers
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var volunteers = await volunteerService.GetAllVolunteersAsync();
            return View(volunteers); // Pass the data to the "Index" view
        }

        // Volunteer details
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var volunteer = await volunteerService.GetVolunteerByIdAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer); // Pass the data to the "Details" view
        }

        // Create a new volunteer - GET
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // Create a new volunteer - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(VolunteerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await volunteerService.AddVolunteerAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // Edit volunteer - GET
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var volunteer = await volunteerService.GetVolunteerByIdAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            var model = new VolunteerFormModel
            {
                Id = volunteer.Id,
                Name = volunteer.Name,
                ContactInfo = volunteer.ContactInfo,
                Task = volunteer.Task,
                StartDate = volunteer.StartDate,
                EndDate = volunteer.EndDate
            };

            return View(model);
        }

        // Edit volunteer - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, VolunteerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await volunteerService.UpdateVolunteerAsync(id, model);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // Delete volunteer - GET
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var volunteer = await volunteerService.GetVolunteerByIdAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer); // Pass the data to the "Delete" view
        }

        // Delete volunteer - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var success = await volunteerService.DeleteVolunteerAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
