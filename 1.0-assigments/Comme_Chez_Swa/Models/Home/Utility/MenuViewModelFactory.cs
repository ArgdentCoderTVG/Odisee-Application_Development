using Comme_Chez_Swa.Controllers;
using Comme_Chez_Swa.Models.Menu;

namespace Comme_Chez_Swa.Models.Home.Menu
{
    public static class MenuViewModelFactory
    {
        public static MenuViewModel CreateMenuViewModel(string strId)
        {
            Models.Menu.Menu displayedMenu = MenuController.MenuRepository.GetById(strId);

            return new MenuViewModel(displayedMenu);
        }
    }
}
