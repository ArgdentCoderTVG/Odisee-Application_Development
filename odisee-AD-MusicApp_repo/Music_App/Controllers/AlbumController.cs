using Microsoft.AspNetCore.Mvc;
using Music_App.Models;
using Music_App.Models.ViewModels;
using System.Diagnostics;

namespace Music_App.Controllers
{
    public class AlbumController : Controller
    {
        #region Note to Reader
        
        // Code effectively duplicated via comments (i know, code verbosity != comments) for self-inprovement purposes
        // Attempting to differentiate by heart between declare, initialise, both (define), implement (declare + {}) etc.

        // [INTENT] --> What's the intent of this code
        // [DESCR] --> What's the descriptive term for this code
        // [NOTE] --> What's (advanced and/or) technical about this code

        #endregion

        #region Instance Variables

        // [INTENT] Declare: backing variable for logger
        private readonly ILogger<AlbumController> _logger;

        #endregion

        #region Properties

        // [INTENT] Define: automatic property for repository (I want all to use same repo)
        public AlbumRepository LocalAlbumRepository { get; private set; }

        #endregion

        #region Constructor

        // [DESCR] Constructor (argumented)
        public AlbumController(ILogger<AlbumController> logger)
        {
            // Initialise: instance variable values
            _logger = logger;

            // Initialise: instance property values
            LocalAlbumRepository = new AlbumRepository();
        }

        #endregion

        #region Controller Actions

        // [DESCR] Index Controller Action
        public IActionResult Index()
        {
            // Define: viewmodel via object initialiser
            AlbumViewModel albumViewModel = new AlbumViewModel { Albums = LocalAlbumRepository.GetAll() };

            // Delivery: passing viewmodel to view
            return View(albumViewModel);
        }

        // [DESCR] AlbumDetails Controller Action
        public IActionResult AlbumDetails(int albumId)
        {
            // Define: album as repo id-filtering result
            Album album = LocalAlbumRepository.FindById(albumId);

            // Define: viewmodel via object initialiser
            AlbumDetailsViewModel albumDetailsViewModel = new AlbumDetailsViewModel { Album = album };

            // Delivery: passing viewmodel to view
            return View(albumDetailsViewModel);
        }

        // [DESCR] Privacy Controller Action
        // [NOTE TO READER] Present in assigment examples, not deleted.
        public IActionResult Privacy()
        {
            return View();
        }

        // [DESCR] Error Controller Action 
        // [NOTE] for non-cache erroneous content handling via C# attribute; Activity ID provided by System.Diagnostics tracing
        // [NOTE TO READER] Useful action, not deleted.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Define: viewmodel via object initialiser
            ErrorViewModel errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

            // Delivery: passing viewmodel to view
            return View(errorViewModel);
        }

        #endregion
    }
}