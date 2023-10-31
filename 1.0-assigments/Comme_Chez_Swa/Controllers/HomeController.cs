using Comme_Chez_Swa.Exceptions;
using Comme_Chez_Swa.Models;
using Comme_Chez_Swa.Models.Home;
using Comme_Chez_Swa.Models.Home.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Comme_Chez_Swa.Controllers
{
    public class HomeController : Controller
    {
        private const string RESOURCES_FILE_LOCATION = "wwwroot/json/resourceConfig.json";
        private const string NAME_OF_RESTAURANT = "Comme Chez Swa";
        private const string MENU_TIMEBASED_TEXT_TEMPLATE = $"Neem snel een kijkje naar ons heerlijke {TimeBasedMenuContent.MENUTYPE_PLACEHOLDER} menu!";

        #region Index
        // [ESSENCE] Home controller Index action
        public IActionResult Index()
        {
            // Initialise data
            GenerateViewDataItems();
            TimeBasedMenuContent timeBasedMenuContentObject = GenerateTimeBasedMenuObject();

            // Construct the output
            IndexViewModel indexViewModel = new IndexViewModel(timeBasedMenuContentObject);

            // Assign or return the output
            return View(indexViewModel);
        }

        private void GenerateViewDataItems()
        {
            // Initialise with values
            ViewData["Title"] = NAME_OF_RESTAURANT;

            // Initialise with logic
            GenerateViewDataResourcePathsDictionary();
        }

        private void GenerateViewDataResourcePathsDictionary()
        {
            // Define the in-/ and output
            string resourcePathsJsonUrl = System.IO.File.ReadAllText(RESOURCES_FILE_LOCATION);
            Dictionary<string, object> dictResourcePaths = new Dictionary<string, object>();

            // Produce a result
            using (JsonDocument jsonResourcesDocument = JsonDocument.Parse(resourcePathsJsonUrl))
            {
                foreach (JsonProperty jsonProperty in jsonResourcesDocument.RootElement.EnumerateObject())
                {
                    dictResourcePaths[jsonProperty.Name] = 
                        jsonProperty.Value.GetString() ?? 
                        throw new JsonReadException($"JSON property name \"{jsonProperty.Name}\" was null");
                }
            }

            // Assign or return the output
            ViewData["ImageConfig"] = dictResourcePaths;
        }

        private TimeBasedMenuContent GenerateTimeBasedMenuObject()
        {
            // Define the in-/ and output
            string fullTimeBasedMenuTextWithPlaceholder = MENU_TIMEBASED_TEXT_TEMPLATE;
            string targetMenuControllerName = nameof(HomeController).Replace("Controller", "");
            string targetMenuControllerActionName = nameof(HomeController.Menu);

            // Construct the output
            TimeBasedMenuContent timeBasedMenuTextObject = new TimeBasedMenuContent(fullTimeBasedMenuTextWithPlaceholder, targetMenuControllerName, targetMenuControllerActionName);

            // Assign or return the output
            return timeBasedMenuTextObject;
        }
        #endregion

        // [ESSENCE] Home controller About action 
        public IActionResult About()
        {
            //string aboutUsHeadingText = String.Empty;
            //string aboutUsContentText = String.Empty;

            //AboutViewModel aboutViewModel = new AboutViewModel(aboutUsHeadingText, aboutUsContentText);

            return View();
        }

        // [ESSENCE] Home controller Menu action 
        public IActionResult Menu(TimeBasedMenuContent menuTextWithPageLinkMVC)
        {
            //string menuTitle = String.Empty;
            //string menuDescription = String.Empty;
            //ImmutableArray<MenuSection> sections = new ImmutableArray<MenuSection>();

            //MenuViewModel menuViewModel = new MenuViewModel("","", new ImmutableArray<MenuSection>());

            return View();
        }

        // [ESSENCE] Home controller Reservations action 
        public IActionResult Reservations()
        {
            //ImmutableArray<Reservation> reservationsAll = new ImmutableArray<Reservation>();
            //Reservations reservations = new Reservations(reservationsAll);

            //ReservationsViewModel reservationsViewModel = new ReservationsViewModel(reservations);

            return View();
        }

        // [ESSENCE] Home controller (catched) error action 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Define the in-/ and output
            ErrorViewModel errorViewModel = new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier);

            // Assign or return the output
            return View(errorViewModel);
        }

        //TODO: I need a modal popping up and telling me about erros instead of a full page (i.e. handle errors)
    }
}