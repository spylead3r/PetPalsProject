using Microsoft.AspNetCore.Mvc;
using PetPals.Services.Data;
using PetPals.Services.Data.Interfaces;

public class HomeController : Controller
{
    private readonly IPetService petService;

    public HomeController(IPetService petService)
    {
        this.petService = petService;
    }


    public async Task<IActionResult> Index()
    {
        var pets = await this.petService.GetAllPetsWithPhotoAsync();
        return View(pets);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}