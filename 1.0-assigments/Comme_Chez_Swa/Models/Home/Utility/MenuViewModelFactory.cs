using Comme_Chez_Swa.Controllers;
using Comme_Chez_Swa.Models.Home.Utility;
using System.Collections.Immutable;

namespace Comme_Chez_Swa.Models.Home.Menu
{
    public static class MenuViewModelFactory
    {
        public static MenuViewModel CreateMenuViewModel()
        {
            TimeBasedMenuContent? timeBasedMenuContent = HomeController.TimeBasedMenuContentObject;

            string timeBasedMenuText = timeBasedMenuContent?.TimeBasedMenuTextWithMenuTypeValue ?? throw new NullReferenceException();
            string timeBasedGreetingText = timeBasedMenuContent.TimeBasedGreetingType.ToString() ?? throw new NullReferenceException();
            ImmutableArray<MenuSection>? sections = default;

            switch (timeBasedMenuContent.TimeBasedMenuType)
            {
                case EnumMenuType.Ontbijt:
                    sections = GetSectionsForTypeOntbijt();
                    break;
                case EnumMenuType.Lunch:
                    sections = GetSectionsForTypeLunch();
                    break;
                case EnumMenuType.Suggestie:
                    sections = GetSectionsForTypeSuggestie();
                    break;
            }

            return new MenuViewModel(timeBasedGreetingText, timeBasedMenuText, sections);
        }

        private static ImmutableArray<MenuSection>? GetSectionsForTypeOntbijt()
        {
            return null;
        }

        private static ImmutableArray<MenuSection>? GetSectionsForTypeLunch()
        {
            return null;
        }

        private static ImmutableArray<MenuSection>? GetSectionsForTypeSuggestie()
        {
            return null;
        }
    }
}
