namespace Comme_Chez_Swa.Models.Home.Utility
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class DynamicMenuContent
    {
        public const string MENUTYPEPLACEHOLDER = "{0}";

        public string FullText { get {
                return $"{PartBeforeLinkElementText} {MENUTYPEPLACEHOLDER} {PartAfterLinkElementText}";
            } }
        public EnumMenuType GeneratedMenuType { get; private set; }
        public EnumGreetingType GeneratedGreetingType { get; private set; }
        public string NameOfActionMVC { get; }
        public string NameOfControllerMVC { get; }

        public string PartBeforeLinkElementText { get; private set; }
        public string PartLinkElementText { get; private set; }
        public string PartAfterLinkElementText { get; private set; }

        // [NOTE] One entry point for altering the object state
        public DynamicMenuContent(string fullText, string nameOfControllerMVC, string nameOfActionMVC)
        {
            // Initialise exposed properties
            InitialisePropsBasedOnPartOfDay();
            InitialisePropsTextComponentsUsingFullText(fullText);

            NameOfControllerMVC = nameOfControllerMVC;
            NameOfActionMVC = nameOfActionMVC;
        }

        private void InitialisePropsTextComponentsUsingFullText(string fullText)
        {
            string input = fullText;
            string placeholder = MENUTYPEPLACEHOLDER;
            int placeholderIndex = input.IndexOf(placeholder);

            PartBeforeLinkElementText = input.Substring(0, placeholderIndex);
            PartAfterLinkElementText = input.Substring(placeholderIndex + placeholder.Length);
        }

        private void InitialisePropsBasedOnPartOfDay()
        {
            // TODO: Implicit casting, but I actually dont know when to use implicit/explicit
            byte currentHour = (byte)DateTime.Now.Hour;

            EnumMenuType menuType = default;
            EnumGreetingType greetingType = default;

            Func<int, bool> isGivenHourBefore11AM = (funcCurrentHour) => { return (funcCurrentHour > 11); };
            Func<int, bool> isGivenHourBetween11AM_NotIncluded2PM = (funcCurrentHour) => { return (funcCurrentHour >= 11 && funcCurrentHour < 14); };
            Func<int, bool> isGivenHourBetween2PM_NotIncluded5PM = (funcCurrentHour) => { return (funcCurrentHour >= 14 && funcCurrentHour < 17); };
            Func<int, bool> isGivenHourAfter5PM = (funcCurrentHour) => { return (funcCurrentHour >= 17); };

            // TODO: This feels like a switch statement, but cant be done using a switch?
            if (isGivenHourBefore11AM(currentHour))
            {
                menuType = EnumMenuType.Ontbijt;
                greetingType = EnumGreetingType.Goeiemorgen;
            }
            else if (isGivenHourBetween11AM_NotIncluded2PM(currentHour))
            {
                menuType = EnumMenuType.Lunch;
                greetingType = EnumGreetingType.Goeiemiddag;
            }
            else if (isGivenHourBetween2PM_NotIncluded5PM(currentHour))
            {
                menuType = EnumMenuType.Suggestie;
                greetingType = EnumGreetingType.Welkom;
            }
            else if (isGivenHourAfter5PM(currentHour))
            {
                menuType = EnumMenuType.Suggestie;
                greetingType = EnumGreetingType.Goeienavond;
            }

            GeneratedMenuType = menuType;
            GeneratedGreetingType = greetingType;
        }
    }
}