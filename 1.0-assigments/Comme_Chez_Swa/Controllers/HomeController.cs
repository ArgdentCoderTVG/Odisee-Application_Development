using Comme_Chez_Swa.Exceptions;
using Comme_Chez_Swa.Models;
using Comme_Chez_Swa.Models.Home;
using Comme_Chez_Swa.Models.Home.Menu;
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
        public static TimeBasedMenuContent? TimeBasedMenuContentObject { get; private set;}

        #region Index
        public IActionResult Index()
        {
            // Initialise data
            GenerateViewDataItems();
            TimeBasedMenuContentObject = TimeBasedMenuContent.GenerateTimeBasedMenuObject();

            // Construct the output
            IndexViewModel indexViewModel = new IndexViewModel(TimeBasedMenuContentObject);

            // Assign or return the output
            return View(indexViewModel);
        }

        private void GenerateViewDataItems(Action? specificViewDataItems = default)
        {
            // Initialise with values
            ViewData["Title"] = NAME_OF_RESTAURANT;

            // Initialise with logic
            GenerateViewDataResourcePathsDictionary();

            // Initialise by referenced logic
            specificViewDataItems?.Invoke();
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
        #endregion

        #region AboutUs
        public IActionResult About()
        {
            // Define the in-/ and output
            string aboutUsHeadingText = "Over Ons";
            string aboutUsContentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non.\r\nVivamus eget nunc vitae odio facilisis faucibus in et sapien.\r\nPellentesque habitant morbi tristique senectus et netus et malesuada fames.\r\nSuspendisse potenti. Curabitur ac libero leo, in faucibus orci.\r\nPhasellus imperdiet, nulla et dictum interdum, nisi lorem egestas vitae.\r\nCras maximus felis vitae enim pellentesque, sed sollicitudin mi gravida.\r\nAenean laoreet mi in malesuada feugiat. Nullam eget felis velit.\r\nInteger dapibus, mi ac tempor fermentum, ipsum nisi dignissim lacus.\r\nFusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh.\r\nUt fermentum massa justo, sit amet risus etiam ultricies vehicula.\r\nDonec id elit non mi porta gravida at eget metus.\r\nSed posuere consectetur est at lobortis. Donec ullamcorper nulla non.\r\n";

            // Construct the output
            AboutViewModel aboutViewModel = new AboutViewModel(aboutUsHeadingText, aboutUsContentText);

            // Assign or return the output
            return View(aboutViewModel);
        }
        #endregion

        public IActionResult Reservations()
        {
            //ImmutableArray<Reservation> reservationsAll = new ImmutableArray<Reservation>();
            //Reservations reservations = new Reservations(reservationsAll);

            //ReservationsViewModel reservationsViewModel = new ReservationsViewModel(reservations);

            return View();
        }

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