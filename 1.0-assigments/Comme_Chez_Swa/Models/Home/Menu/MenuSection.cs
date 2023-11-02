using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace Comme_Chez_Swa.Models.Home.Menu
{
    public class MenuSection
    {
        public string SectionName { get; set; }
        public ImmutableArray<MenuItem>? MenuItems { get; set; }

        public MenuSection(string sectionName, ImmutableArray<MenuItem>? menuItems = null)
        {
            SectionName = sectionName;
            MenuItems = menuItems;
        }
    }
}
