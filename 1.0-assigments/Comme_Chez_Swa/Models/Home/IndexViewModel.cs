using Comme_Chez_Swa.Models.Home.Utility;

namespace Comme_Chez_Swa.Models.Home
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class IndexViewModel : BaseViewModel
    {
        public string DynamicGreetingText { get; }
        public MenuTextWithPageLinkMVC DynamicMenuText { get; }
        public string RestaurantLogoSource { get; }

        // [NOTE] One entry point for altering the object state
        /* [NOTE] Choice: - either have an instance argument - OR - input arguments for creating the instance here -
         *  Principle of Least Astonishment:
         *      The constructor should always do the least surprising thing.
         *      This class uses the instance in the same way, every time, so its unsurprising that creating the instance happens elsewhere.
         *      
         *  Single Responsability Principle (SRP)
         *      This POCO viewmodel is assigned with holding data, not creating it.
         *      
         *  Dependency Inversion Principle (DIP)
         *      By correctly requiring a type instance, we are depending on the caller.
         *      By incorrectly requiring the instance arguments, the caller is depending on us.
         *      If done incorrectly, all implementations of requiring instance arguments over the instance itself would have to change if the class constructor signature changed.
         *      
         *  Open/Closed Principle (OCP) and Liskov Priciple (LSP)
         *      By requiring a type instance, this class is able to accept subclasses or changed versions of the instance type. (open for extension)
         *      By requiring a type instance, this class is able to accept extension without ever having to change THIS signature/syntax. (closed for change)
         *      
         *  Robert Cecil Martin advice from book Clean Code
         *      A method should be monadic, dyadic and at the very most triadic. (amount of parameters) Anything more points to a method doing too much of 1 thing, or more than 1 thing.
         */

        public IndexViewModel(string dynamicGreetingText, MenuTextWithPageLinkMVC dynamicMenuText, string restaurantLogoSource)
        {
            DynamicMenuText = dynamicMenuText;
            DynamicGreetingText = dynamicGreetingText;
            RestaurantLogoSource = restaurantLogoSource;
        }
    }
}