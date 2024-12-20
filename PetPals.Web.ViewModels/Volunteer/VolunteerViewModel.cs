using System;


namespace PetPals.Web.ViewModels.Volunteer
{
    public class VolunteerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Task { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
