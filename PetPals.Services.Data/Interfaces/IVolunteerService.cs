using PetPals.Web.ViewModels.Volunteer;


namespace PetPals.Services.Data.Interfaces
{
    public interface IVolunteerService
    {
        Task<List<VolunteerViewModel>> GetAllVolunteersAsync();
        Task<VolunteerFormModel?> GetVolunteerByIdAsync(Guid id);
        Task AddVolunteerAsync(VolunteerFormModel model);
        Task<bool> UpdateVolunteerAsync(Guid id, VolunteerFormModel model);
        Task<bool> DeleteVolunteerAsync(Guid id);
    }
}
