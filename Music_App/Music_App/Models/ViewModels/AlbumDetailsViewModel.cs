namespace Music_App.Models.ViewModels
{
    public class AlbumDetailsViewModel
    {
        // Automatic properties -> simple POCO enumeration
        public Album? Album { get; set; }

        // Default constructor -> Inialisation logic, Dependecy injection & Data validation are controller responasbility (SRP -> viewmodel -> only datacarrier)
    }
}
