using Comme_Chez_Swa.Models.Home.Utility;

namespace Comme_Chez_Swa.Models.Home
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class IndexViewModel : BaseViewModel
    {
        public TimeBasedMenuContent TimeBasedMenuContentObject { get; }

        public IndexViewModel(TimeBasedMenuContent timeBasedMenuContentObject)
        {
            TimeBasedMenuContentObject = timeBasedMenuContentObject;
        }
    }
}