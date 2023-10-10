using Microsoft.AspNetCore.Mvc;
using Mijn_CV.Models;
using System.Diagnostics;

namespace Mijn_CV.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return OnePieceQualities();
		}

        public IActionResult OnePieceQualities()
        {
            List<OnePieceQuality> onePieceQualities = new List<OnePieceQuality>
            {
                new OnePieceQuality("Netflix Adaptation!", "Accessible if watching the Anime is a bit of a step!", "/img/one_piece-netflix-2.jpg", "https://www.imdb.com/title/tt11737520/"),
                new OnePieceQuality("Published movies!", "More of a dive-in kind of person?", "/img/one_piece-strong_world.jpg", "https://www.imdb.com/title/tt1485763/"),
                new OnePieceQuality("Mainstream recognition!", "Even a boring, real newspaper has to admit things!", "/img/one_piece-the_guardian.jpg", "https://www.theguardian.com/culture/2021/nov/19/japanese-anime-one-piece-to-air-its-1000th-episode-in-80-countries"),
                new OnePieceQuality("Rich, even heartfelt stories!", "Complex themes: slavery, hatred, extreme censorship", "/img/one_piece-slavery.jpg", "https://gamerant.com/real-world-themes-explored-in-one-piece/"),
                new OnePieceQuality("Qualitative fights!", "One piece holds the title for longest animated fight!", "/img/one_piece-luffy_vs_katakuri.jpg", "https://youtu.be/JWR5ugPMICc?t=611"),
                new OnePieceQuality("Exceptional animating!", "(Eventually) Top level animation that shook Anime worldwide!", "/img/one_piece-zoro_vs_king.jpg", "https://youtu.be/Zuu6ClXRabE"),
            };

            OnePieceQualitiesModel viewModel = new OnePieceQualitiesModel(onePieceQualities);

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}