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

        private AlbumViewModel FactoryAlbumViewModel()
        {
            return new AlbumViewModel
            {
                Albums = new List<Album> {
                    new Album{ Id=2,
                        Title = "X",
                        Artist = "Ed Sheeran",
                        Rating = 10,
                        ImageURL = "/img/ed_sheeran-x-album_image.jpg",
                        Songs = new List<Song> {
                            new Song { Title = "Shirtsleeves", Length = (3*60)+10},
                            new Song { Title = "One", Length = (4*60)+13},
                            new Song { Title = "Even My Dad Does Sometimes", Length = (3*60)+49},
                            new Song { Title = "Take It Back", Length = (3*60)+28},
                            new Song { Title = "Afire Love", Length = (5*60)+14},
                            new Song { Title = "Bloodstream", Length = (5*60)},
                            new Song { Title = "The Man", Length = (4*60)+10},
                            new Song { Title = "All of the Stars", Length = (3*60)+57},
                            new Song { Title = "Sing", Length = (3*60)+55},
                            new Song { Title = "Photograph", Length = (4*60)+19},
                            new Song { Title = "Tenerife Sea", Length = (4*60)+1},
                            new Song { Title = "I'm a Mess", Length = (4*60)+5},
                            new Song { Title = "Nina", Length = (3*60)+46},
                            new Song { Title = "Runaway", Length = (3*60)+25},
                            new Song { Title = "Thinking Out Load", Length = (4*60)+42},
                            new Song { Title = "I See Fire", Length = (4*60)+58},
                            new Song { Title = "Don't", Length = (3*60)+42},
                        }
                    },
                    new Album{ Id=2,
                        Title = "1989",
                        Artist = "Taylor Shift",
                        Rating = 10,
                        ImageURL = "/img/taylor_swift-1989-album_image.jpg",
                        Songs = new List<Song> {
                            new Song { Title = "All You Had to Do Was Stay", Length = (4*60)+13},
                            new Song { Title = "I Know Places", Length = (3*60)+16},
                            new Song { Title = "I Wish You Would", Length = (3*60)+27},
                            new Song { Title = "This Love", Length = (4*60)+10},
                            new Song { Title = "Blank Space", Length = (3*60)+52},
                            new Song { Title = "Welcome To New York", Length = (3*60)+33},
                            new Song { Title = "Wildest Dreams", Length = (3*60)+40},
                            new Song { Title = "Shake It Off", Length = (3*60)+39},
                            new Song { Title = "Style", Length = (3*60)+51},
                            new Song { Title = "Clean", Length = (4*60)+31},
                            new Song { Title = "How You Get the Girl", Length = (4*60)+8},
                            new Song { Title = "Out of the Woods", Length = (3*60)+56},
                            new Song { Title = "Bad Blood", Length = (3*60)+32}
                        }
                    },
                    new Album{ Id=3,
                        Title = "A Few Small Repairs",
                        Artist = "Shawn Colvin",
                        Rating = 2,
                        ImageURL = "/img/shawn_colvin-a_few_small_repairs-album_image.jpg",
                        Songs = new List<Song> {
                            new Song { Title = "Wichita Skyline", Length = (3*60)+39},
                            new Song { Title = "If I were Brave", Length = (3*60)+12},
                            new Song { Title = "Sunny Came Home", Length = (4*60)+25},
                            new Song { Title = "Nothin on Me", Length = (3*60)+57},
                            new Song { Title = "The Facts About Jimmy", Length = (5*60)+24},
                            new Song { Title = "Suicide ALley", Length = (5*60)+31},
                            new Song { Title = "Trouble", Length = (4*60)+18},
                            new Song { Title = "You and the Mona Lisa", Length = (4*60)+6},
                            new Song { Title = "Get Out Of This House", Length = (4*60)+15},
                            new Song { Title = "84,000 Different Delusions", Length = (4*60)+2},
                            new Song { Title = "I Want It Back", Length = (4*60)+57},
                            new Song { Title = "Net Thing Now", Length = (3*60)+34}
                        }
                    },
                    new Album{ Id=4,
                        Title = "Back In Black",
                        Artist = "AC/DC",
                        Rating = 10,
                        ImageURL = "/img/ac_dc-back_in_black-album_image-2.jpg",
                        Songs = new List<Song> {
                            new Song { Title = "What Do You Do For Money", Length = (3*60)+35},
                            new Song { Title = "Hells Bells", Length = (5*60)+12},
                            new Song { Title = "Let ME Put My Love into You", Length = (4*60)+15},
                            new Song { Title = "Shake A Leg", Length = (4*60)+5},
                            new Song { Title = "You Shook Me All Night Long", Length = (3*60)+30},
                            new Song { Title = "Have A Drink On Me", Length = (3*60)+59},
                            new Song { Title = "Back In Black", Length = (4*60)+16},
                            new Song { Title = "Givin The Dog A Bone", Length = (3*60)+32},
                            new Song { Title = "Roch and Roill Ain't Noise Pollution", Length = (4*60)+14},
                            new Song { Title = "Shoot to Thrill", Length = (5*60)+18}
                        }
                    },
                    new Album{ Id=5,
                        Title = "Soundtrack album The Greatest Showman",
                        Artist = "The Greatest Showman cast",
                        Rating = 10,
                        ImageURL = "/img/the_greatest_showman-album_image.jpg",
                        Songs = new List<Song> {
                            new Song { Title = "A Million Dreams", Length = (4*60)+29},
                            new Song { Title = "Tightrope", Length = (3*60)+54},
                            new Song { Title = "Rewrite the Stars", Length = (3*60)+37},
                            new Song { Title = "The Other Side", Length = (3*60)+34},
                            new Song { Title = "The Greatest Show", Length = (5*60)+2},
                            new Song { Title = "This Is Me", Length = (3*60)+55},
                            new Song { Title = "Never Enough", Length = (3*60)+28},
                            new Song { Title = "Never Enough - Reprise", Length = (1*60)+20},
                            new Song { Title = "A Million Dreams - Reprise", Length = (1*60)},
                            new Song { Title = "Come Alive", Length = (3*60)+46},
                            new Song { Title = "From Now On", Length = (5*60)+50}
                        }
                    },
                    new Album{ Id=6,
                        Title = "Plus",
                        Artist = "Ed Sheeran",
                        Rating = 10,
                        ImageURL = "/img/ed_sheeran-plus-album_image.jpg",
                        Songs = new List<Song> {
                            new Song { Title = "Wake Me Up", Length = (3*60)+49},
                            new Song { Title = "The City", Length = (3*60)+54},
                            new Song { Title = "The A Team", Length = (4*60)+20},
                            new Song { Title = "Kiss Me", Length = (4*60)+40},
                            new Song { Title = "Give Me Love", Length = (8*60)+46},
                            new Song { Title = "U.N.I.", Length = (3*60)+58},
                            new Song { Title = "Drunk", Length = (3*60)+20},
                            new Song { Title = "This", Length = (3*60)+15},
                            new Song { Title = "Lego House", Length = (3*60)+5},
                            new Song { Title = "Grade 8", Length = (2*60)+59},
                            new Song { Title = "Small Bump", Length = (4*60)+19},
                            new Song { Title = "You Need Me, I Don't Need You", Length = (3*60)+40}
                        }
                    },
                }
            };
        }
    }
}