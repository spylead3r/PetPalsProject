using PetPals.Data.Models;
using PetPals.Web.ViewModels.Pet;

public class HomePageViewModel
{
    public IEnumerable<PetIndexViewModel> Pets { get; set; }
    public IEnumerable<Event> Events { get; set; }
}
