using Microsoft.AspNetCore.Mvc;
using Mijn_CV.Models.DataModels;
using Mijn_CV.Models.ViewModels;
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
            List<OnePieceQuality> onePieceQualities = new List<OnePieceQuality>
            {
                new OnePieceQuality("Netflix adaptation!", "Accessible if watching the Anime is a bit of a step!", "/img/one_piece-netflix-2.jpg", "https://www.imdb.com/title/tt11737520/"),
                new OnePieceQuality("Published movies!", "More of a dive-in kind of person?", "/img/one_piece-strong_world.jpg", "https://www.imdb.com/title/tt1485763/"),
                new OnePieceQuality("Mainstream recognition!", "Even a boring, real newspaper has to admit things!", "/img/one_piece-the_guardian.jpg", "https://www.theguardian.com/culture/2021/nov/19/japanese-anime-one-piece-to-air-its-1000th-episode-in-80-countries"),
                new OnePieceQuality("Rich and heartfelt stories!", "Complex themes: slavery, hatred, extreme censorship", "/img/one_piece-slavery.jpg", "https://gamerant.com/real-world-themes-explored-in-one-piece/"),
                new OnePieceQuality("Qualitative fights!", "One piece holds the title for longest animated fight!", "/img/one_piece-luffy_vs_katakuri.jpg", "https://youtu.be/JWR5ugPMICc?t=611"),
                new OnePieceQuality("Exceptional animation!", "(Currently) Top level animation that shook Anime worldwide!", "/img/one_piece-zoro_vs_king.jpg", "https://youtu.be/Zuu6ClXRabE"),
            };

            List<OnePieceCharacter> onePieceCharacters = new List<OnePieceCharacter>
            {
                new OnePieceCharacter("Luffy", "Fifth Emperor of the Sea; Joy Boy", "Straw hat Pirates", new DateTime(2004,5,5), "The captain of the Straw hat pirates!", "/img/one_piece-luffy.jpg", "https://onepiece.fandom.com/wiki/Monkey_D._Luffy"),
                new OnePieceCharacter("Zoro", "Pirate Hunter; King of Hell", "Straw hat Pirates", new DateTime(2002,11,11), "The swordsman of the Straw hat pirates!", "/img/one_piece-zoro.jpg", "https://onepiece.fandom.com/wiki/Roronoa_Zoro"),
                new OnePieceCharacter("Sanji", "Black leg; Germa 6 prince", "Straw hat Pirates", new DateTime(2002,3,2), "The cook of the Straw hat pirates!", "/img/one_piece-sanji.jpg", "https://onepiece.fandom.com/wiki/Sanji")
            };

            OnePieceDevilFruit onePieceDevilFruit = new OnePieceDevilFruit("Gomu Gomu no Mi", "Rubber rubber fruit, also Hito Hito no Mi model Nika", "/img/gomu_gomu_no_mi.jpg", "https://onepiece.fandom.com/wiki/Gomu_Gomu_no_Mi");

            HomeViewModel viewModel = new HomeViewModel(onePieceQualities, onePieceCharacters, onePieceDevilFruit);

            return View(viewModel);
        }

        public IActionResult DevilFruit()
        {
            OnePieceDevilFruit onePieceDevilFruit = new OnePieceDevilFruit("Gomu Gomu no Mi", "Rubber rubber fruit, also Hito Hito no Mi model Nika", "/img/one_piece-gomu_gomu_no_mi.jpg", "https://onepiece.fandom.com/wiki/Gomu_Gomu_no_Mi");

            DevilFruitViewModel viewModel = new DevilFruitViewModel(onePieceDevilFruit);

            return View(viewModel);
        }

        public IActionResult Sanji()
        {
            OnePieceCharacter sanji = new OnePieceCharacter("Sanji", "Black leg; Germa 6 prince", "Straw hat Pirates", new DateTime(2002, 3, 2), "The cook of the Straw hat pirates!", "/img/one_piece-sanji.jpg", "https://onepiece.fandom.com/wiki/Sanji");

            SanjiViewModel viewModel = new SanjiViewModel(sanji);

            return View(viewModel);
        }

        public IActionResult Zoro()
        {
            OnePieceCharacter zoro = new OnePieceCharacter("Zoro", "Pirate Hunter; King of Hell", "Straw hat Pirates", new DateTime(2002, 11, 11), "The swordsman of the Straw hat pirates!", "/img/one_piece-zoro.jpg", "https://onepiece.fandom.com/wiki/Roronoa_Zoro");

            ZoroViewModel viewModel = new ZoroViewModel(zoro);

            return View(viewModel);
        }

        public IActionResult Luffy()
        {
            OnePieceCharacter luffy = new OnePieceCharacter("Luffy", "Fifth Emperor of the Sea; Joy Boy", "Straw hat Pirates", new DateTime(2004, 5, 5), "The captain of the Straw hat pirates!", "/img/one_piece-luffy.jpg", "https://onepiece.fandom.com/wiki/Monkey_D._Luffy");

            LuffyViewModel viewModel = new LuffyViewModel(luffy);

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}