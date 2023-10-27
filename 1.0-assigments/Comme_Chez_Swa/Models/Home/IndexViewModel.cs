namespace Comme_Chez_Swa.Models.Home
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class IndexViewModel : BaseViewModel
    {
        public string DynamicGreetingText { get; }
        public string DynamicMenuText { get; }
        public string RestaurantLogoSource { get; }

        // [NOTE] One entry point for altering the object state
        public IndexViewModel(string dynamicGreetingText, string dynamicMenuText, string restaurantLogoSource)
        {
            DynamicGreetingText = dynamicGreetingText;
            DynamicMenuText = dynamicMenuText;
            RestaurantLogoSource = restaurantLogoSource;
        }
    }
}