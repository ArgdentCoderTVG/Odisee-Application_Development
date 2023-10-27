using Comme_Chez_Swa.Models;
using Comme_Chez_Swa.Models.Home;
using Comme_Chez_Swa.Models.Home.Menu;
using Comme_Chez_Swa.Models.Home.Reservations;
using Comme_Chez_Swa.Models.Home.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Comme_Chez_Swa.Controllers
{
    public enum MenuTypes /* TODO: Is this the correct name(convention) using ...Types? */
    {
        Ontbijt,
        Lunch,
        Suggestie
    }
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
            // Arrange data
            string dynamicGreetingText = "Greeting placeholder";
            MenuTextWithPageLinkMVC dynamicMenuText = GenerateDynamicMenuText(); 
            string restaurantLogoSource = "/img/logo_comme_chez_swa.png";

            IndexViewModel indexViewModel = new IndexViewModel(dynamicGreetingText, dynamicMenuText, restaurantLogoSource);

            // Act
            return View(indexViewModel);
		}

        private MenuTextWithPageLinkMVC GenerateDynamicMenuText()
        {
            // TODO: Implicit casting, but I actually dont know when to use implicit/explicit
            byte currentHour = (byte)DateTime.Now.Hour;

            MenuTypes menuType = default;

            Func<int, bool> isGivenHourBefore11AM = (funcCurrentHour) => { return (funcCurrentHour > 11); };
            Func<int, bool> isGivenHourBetween11AM_NotIncluded2PM = (funcCurrentHour) => { return (funcCurrentHour >= 11 && funcCurrentHour < 14); };
            Func<int, bool> isGivenHourBetween2PM_NotIncluded5PM = (funcCurrentHour) => { return (funcCurrentHour >= 14 && funcCurrentHour < 17); };
            Func<int, bool> isGivenHourAfter5PM = (funcCurrentHour) => { return (funcCurrentHour >= 17); };

            // TODO: This feels like a switch statement, but cant be done using a switch?
            if (isGivenHourBefore11AM(currentHour))
            {
                menuType = MenuTypes.Ontbijt;
            }
            else if (isGivenHourBetween11AM_NotIncluded2PM(currentHour))
            {
                menuType = MenuTypes.Lunch;
            }
            else if (isGivenHourBetween2PM_NotIncluded5PM(currentHour))
            {
                menuType = MenuTypes.Suggestie;
            }
            else if (isGivenHourAfter5PM(currentHour))
            {
                menuType = MenuTypes.Suggestie;
            }

            // TODO: I chose the {0} syntax, I need something universally thats not subjective.
            return new MenuTextWithPageLinkMVC("Neem snel een kijkje naar ons heerlijke {0}-menu!","{0}", menuType.ToString(), "Menu", "Home");
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
        public IActionResult Menu()
        {
            // Arrange data
            string menuTitle = String.Empty;
            string menuDescription = String.Empty;
            ImmutableArray<MenuSection> sections = new ImmutableArray<MenuSection>();


            MenuViewModel menuViewModel = new MenuViewModel(menuTitle, menuDescription, sections);

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