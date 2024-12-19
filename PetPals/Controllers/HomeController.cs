using Microsoft.AspNetCore.Mvc;
using PetPals.Services.Data;
using PetPals.Services.Data.Interfaces;

public class HomeController : Controller
{
    private readonly IPetService petService;
    private readonly IEventService eventService;

    public HomeController(IPetService petService, IEventService eventService)
    {
        this.petService = petService;
        this.eventService = eventService;

    }


    public async Task<IActionResult> Index()
    {
        var pets = await this.petService.GetAllPetsWithPhotoAsync(); // Returns PetIndexViewModel
        var events = await this.eventService.GetAllEventsAsync();

        var viewModel = new HomePageViewModel
        {
            Pets = pets,
            Events = events
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}