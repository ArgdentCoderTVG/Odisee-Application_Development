using Comme_Chez_Swa.Models.Home.Menu;
using Comme_Chez_Swa.Models.Home.Utility;
using Comme_Chez_Swa.Models.Menu;
using Microsoft.AspNetCore.Mvc;

namespace Comme_Chez_Swa.Controllers
{
    public class MenuController : Controller
    {
        // Constants
        private const bool SERIOUS_DEVELOPMENT_MODE = false;
        public static readonly Dictionary<int, string> ENUM_MENUTYPE_TO_REPOSITORYID_STRING = new Dictionary<int, string>() {
            { 0, "ONT"},
            { 1, "LUNCH"},
            { 2, "SUGG"}
        };

        // Static variables
        private static MenuRepository _menuRepository = new MenuRepository();
        public static MenuRepository MenuRepository { get { return _menuRepository; } }

        // MVC Actions
        public IActionResult Menu(string menuId)
        {
            // Initialise data

            // Construct the output
            MenuViewModel requestedMenuViewModel = MenuViewModelFactory.CreateMenuViewModel(menuId);

            // Assign or return the output
            return View(requestedMenuViewModel);
        }
    }
}
