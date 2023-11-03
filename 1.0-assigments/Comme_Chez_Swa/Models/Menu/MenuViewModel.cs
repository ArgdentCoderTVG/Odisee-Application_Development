using System.Collections.Immutable;
using Comme_Chez_Swa.Controllers;
using Comme_Chez_Swa.Models.Home;

namespace Comme_Chez_Swa.Models.Menu
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class MenuViewModel : BaseViewModel
    {
        //public string MenuType { get { return HomeController.TimeBasedMenuContentObject.TimeBasedMenuType.ToString(); } }
        public Menu DisplayedMenu { get; }
        public static IEnumerable<Menu> AvailableMenus { get { return MenuController.MenuRepository.GetAll(); } }

        // [NOTE] One entry point for altering the object state
        public MenuViewModel(Menu displayedMenu)
        {
            DisplayedMenu = displayedMenu;
        }
    }
}
