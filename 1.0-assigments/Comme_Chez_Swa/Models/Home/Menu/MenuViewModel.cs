using System.Collections.Immutable;
using Comme_Chez_Swa.Models.Home;

namespace Comme_Chez_Swa.Models.Home.Menu
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class MenuViewModel : BaseViewModel
    {
        // [NOTE] Collections are fixed-size, immutable and simple -> ImmutableArray<Type>
        public string TimeBasedGreetingText { get; }
        public string TimeBasedMenuText { get; }

        // [NOTE] One entry point for altering the object state
        public MenuViewModel(string timeBasedGreetingText, string timeBasedMenuText)
        {
            TimeBasedGreetingText = timeBasedGreetingText;
            TimeBasedMenuText = timeBasedMenuText;
        }
    }
}
