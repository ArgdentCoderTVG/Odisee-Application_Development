using Comme_Chez_Swa.Models;
using Comme_Chez_Swa.Models.Home;
using Comme_Chez_Swa.Models.Home.Menu;
using Comme_Chez_Swa.Models.Home.Reservations;
using Comme_Chez_Swa.Models.Home.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text.Json;
using System.IO;

namespace Comme_Chez_Swa.Controllers
{
    public class HomeController : Controller
    {
        // [ESSENCE] instance backing variable
        private readonly ILogger<HomeController> _logger;

        // [ESSENCE] Constructor (argumented)
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // [ESSENCE] Home controller Index action
        public IActionResult Index()
        {
            LoadResourcesJsonIntoViewData();

            IndexViewModel indexViewModel = new IndexViewModel(GenerateDynamicMenuInstance());

            return View(indexViewModel);
        }

        private void LoadResourcesJsonIntoViewData()
        {
            string json = System.IO.File.ReadAllText("wwwroot/json/imageConfig.json");
            Dictionary<string, object> configData;

            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                configData = new Dictionary<string, object>();

                foreach (JsonProperty property in doc.RootElement.EnumerateObject())
                {
                    configData[property.Name] = property.Value.GetString();
                }
            }

            ViewData["ImageConfig"] = configData;
        }

        private DynamicMenuContent GenerateDynamicMenuInstance()
        {
            string partOfDayBasedMenuFullText = $"Neem snel een kijkje naar ons heerlijke {DynamicMenuContent.MENUTYPEPLACEHOLDER} menu!";
            string controllerName = nameof(HomeController).Replace("Controller", "");
            string actionName = nameof(HomeController.Menu);
            return new DynamicMenuContent(partOfDayBasedMenuFullText, controllerName, actionName);
        }

        

        // [ESSENCE] Home controller About action 
        public IActionResult About()
        {
            // Arrange data
            string aboutUsHeadingText = String.Empty;
            string aboutUsContentText = String.Empty;


            AboutViewModel aboutViewModel = new AboutViewModel(aboutUsHeadingText, aboutUsContentText);

            // Act
            return View();
        }

        // [ESSENCE] Home controller Menu action 
        public IActionResult Menu(DynamicMenuContent menuTextWithPageLinkMVC)
        {
            // Arrange data
            string menuTitle = String.Empty;
            string menuDescription = String.Empty;
            ImmutableArray<MenuSection> sections = new ImmutableArray<MenuSection>();


            MenuViewModel menuViewModel = new MenuViewModel("","", new ImmutableArray<MenuSection>());

            // Act
            return View();
        }

        // [ESSENCE] Home controller Reservations action 
        public IActionResult Reservations()
        {
            // Arrange data
            ImmutableArray<Reservation> reservationsAll = new ImmutableArray<Reservation>();
            Reservations reservations = new Reservations(reservationsAll);

            ReservationsViewModel reservationsViewModel = new ReservationsViewModel(reservations);

            // Act
            return View();
        }

        // [ESSENCE] Home controller (catched) error action 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Arrange data
            ErrorViewModel errorViewModel = new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier);

            // Act
            return View(errorViewModel);
        }
    }
}