using Microsoft.AspNetCore.Mvc;
using Music_App.Models;
using Music_App.Models.ViewModels;
using System.Diagnostics;

namespace Music_App.Controllers
{
    /* TODO:
     * - Fetch albums, songs and images from spotify api
     * - Convert string 4:10 to seconds instead of meaningless calculation
     * - Use factory pattern for indexViewModel initialisation
     */

    public class AlbumController : Controller
    {
        // Logger backing variable definition (declare & initialise)
        private readonly ILogger<AlbumController> _logger;

        // Constructor (argumented)
        public AlbumController(ILogger<AlbumController> logger)
        {
            _logger = logger;
        }

        // Index Controller Action
        public IActionResult Index()
        {
            // Defining output (declare + initialise)
            AlbumViewModel albumViewModel = new AlbumViewModel { Albums = new AlbumRepository().GetAll() };

            // Returning output
            return View(albumViewModel);
        }

        // AlbumDetails Controller Action
        public IActionResult AlbumDetails(int albumId)
        {
            // Defining repositories (declare + initialise)
            AlbumRepository albumRepository = new AlbumRepository();

            // Defining extracted output from repository
            Album album = albumRepository.FindById(albumId);

            // Defining output (declare + initialise)
            AlbumDetailsViewModel albumDetailsViewModel = new AlbumDetailsViewModel { Album = album };

            // Returning output
            return View(albumDetailsViewModel);
        }

        // Privacy Controller Action
        public IActionResult Privacy()
        {
            return View();
        }

        // Error Controller Action (for non-cache erroneous content handling; Activity ID provided by System.Diagnostics tracing)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}