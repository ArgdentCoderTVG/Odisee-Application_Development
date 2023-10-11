namespace Music_App.Models.ViewModels
{
    public class AlbumDetailsViewModel
    {
        // Automatic properties -> simple POCO enumeration
        public List<Song> Songs = new List<Song>();

        // Default constructor -> Inialisation logic, Dependecy injection & Data validation are controller responasbility (SRP -> viewmodel -> only datacarrier)
    }
}
