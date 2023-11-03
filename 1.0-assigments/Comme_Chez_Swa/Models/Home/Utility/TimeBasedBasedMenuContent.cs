using Comme_Chez_Swa.Controllers;

namespace Comme_Chez_Swa.Models.Home.Utility
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class TimeBasedMenuContent
    {
        // Variable members
        public const string MENUTYPE_PLACEHOLDER = "{0}";
        private const string MENU_TIMEBASED_TEXT_TEMPLATE = $"Neem snel een kijkje naar ons heerlijke {TimeBasedMenuContent.MENUTYPE_PLACEHOLDER} menu!";

        // Custom types
        private enum CurrentTimeRange
        {
            BeforeAndNotIncluding11,
            Between11AndNotIncluding14,
            Between14AndNotIncluding17,
            AfterAndIncludingTo17
        }

        // Properties
        public string TimeBasedMenuTextWithPlaceholder => $"{TextBeforeTimeBasedMenuName} {MENUTYPE_PLACEHOLDER} {TextAfterTimeBasedMenuName}";
        public string TimeBasedMenuTextWithMenuTypeValue => $"{TextBeforeTimeBasedMenuName} {TimeBasedMenu.Naam.Replace("menu", "").ToLower()} {TextAfterTimeBasedMenuName}";
        public Comme_Chez_Swa.Models.Menu.Menu TimeBasedMenu { get; private set; }
        public EnumGreetingType TimeBasedGreetingType { get; private set; }

        public string TextBeforeTimeBasedMenuName { get; private set; }
        public string TimeBasedMenuName { get; private set; }
        public string TextAfterTimeBasedMenuName { get; private set; }

        // Constructor
        public TimeBasedMenuContent(string timeBasedMenuTextWithPlaceholder)
        {
            // Initialise with values
            TextBeforeTimeBasedMenuName = String.Empty;
            TimeBasedMenuName = String.Empty;
            TextAfterTimeBasedMenuName = String.Empty;

            // Initlialise with logic
            GenerateDerivedPropertyValues(timeBasedMenuTextWithPlaceholder);
            GenerateTimeBasedPropertyValues();
        }

        // Private logic
        private void GenerateDerivedPropertyValues(string fullText)
        {
            // Define the in-/ and output
            string input = fullText;
            string placeholder = MENUTYPE_PLACEHOLDER;
            int placeholderIndex = input.IndexOf(placeholder);

            // Produce a result
            string localTextBefore = input.Substring(0, placeholderIndex);
            string localTextAfter = input.Substring(placeholderIndex + placeholder.Length);

            // Assign or return the output
            TextBeforeTimeBasedMenuName = localTextBefore;
            TextAfterTimeBasedMenuName = localTextAfter;
        }

        private void GenerateTimeBasedPropertyValues()
        {
            // Define the in-/ and output
            CurrentTimeRange currentTimeRange = GenerateCurrentTimeRange();
            EnumGreetingType greetingType = default;
            string currentSelectedMenuId = string.Empty;

            // Decide the output value
            if (currentTimeRange == CurrentTimeRange.BeforeAndNotIncluding11)
            {
                currentSelectedMenuId = "ONT";
                greetingType = EnumGreetingType.Goeiemorgen;
            }
            else if (currentTimeRange == CurrentTimeRange.Between11AndNotIncluding14)
            {
                currentSelectedMenuId = "LUNCH";
                greetingType = EnumGreetingType.Goeiemiddag;
            }
            else if (currentTimeRange == CurrentTimeRange.Between14AndNotIncluding17)
            {
                currentSelectedMenuId = "SUGG";
                greetingType = EnumGreetingType.Welkom;
            }
            else if (currentTimeRange == CurrentTimeRange.AfterAndIncludingTo17)
            {
                currentSelectedMenuId = "SUGG";
                greetingType = EnumGreetingType.Goeienavond;
            }

            // Assign or return the output
            TimeBasedMenu = MenuController.MenuRepository.GetById(currentSelectedMenuId);
            TimeBasedGreetingType = greetingType;
        }

        private CurrentTimeRange GenerateCurrentTimeRange()
        {
            // Define the in-/ and output
            byte currentHour = (byte)DateTime.Now.Hour;
            CurrentTimeRange currentTimeRange = default;

            // Define the conditions
            Func<int, bool> isGivenHourBefore11AM = (funcCurrentHour) => { return (funcCurrentHour > 11); };
            Func<int, bool> isGivenHourBetween11AM_NotIncluded2PM = (funcCurrentHour) => { return (funcCurrentHour >= 11 && funcCurrentHour < 14); };
            Func<int, bool> isGivenHourBetween2PM_NotIncluded5PM = (funcCurrentHour) => { return (funcCurrentHour >= 14 && funcCurrentHour < 17); };
            Func<int, bool> isGivenHourAfter5PM = (funcCurrentHour) => { return (funcCurrentHour >= 17); };

            // Decide the current time range
            if (isGivenHourBefore11AM(currentHour))
            {
                currentTimeRange = CurrentTimeRange.BeforeAndNotIncluding11;
            }
            else if (isGivenHourBetween11AM_NotIncluded2PM(currentHour))
            {
                currentTimeRange = CurrentTimeRange.Between11AndNotIncluding14;
            }
            else if (isGivenHourBetween2PM_NotIncluded5PM(currentHour))
            {
                currentTimeRange = CurrentTimeRange.Between14AndNotIncluding17;
            }
            else if (isGivenHourAfter5PM(currentHour))
            {
                currentTimeRange = CurrentTimeRange.AfterAndIncludingTo17;
            }

            // Assign or return the output
            return currentTimeRange;
        }

        public static TimeBasedMenuContent GenerateTimeBasedMenuObject()
        {
            // Define the in-/ and output
            string fullTimeBasedMenuTextWithPlaceholder = MENU_TIMEBASED_TEXT_TEMPLATE;

            // Construct the output
            TimeBasedMenuContent timeBasedMenuContentObject = new TimeBasedMenuContent(fullTimeBasedMenuTextWithPlaceholder);

            // Assign or return the output
            return timeBasedMenuContentObject;
        }
    }
}