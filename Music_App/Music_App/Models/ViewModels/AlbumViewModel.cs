namespace Music_App.Models.ViewModels
{
    public class AlbumViewModel
    {
        // Automatic properties -> simple POCO enumeration
        public List<Album> Albums = new List<Album>();

        // Default constructor -> Inialisation logic, Dependecy injection & Data validation are controller responasbility (SRP -> viewmodel -> only datacarrier)
    }
}
