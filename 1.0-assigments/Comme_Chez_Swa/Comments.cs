namespace Comme_Chez_Swa
{
    // [NOTE] One entry point for altering the object state (Constructor)
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

    /* [NOTE] On declaring, and/then initialising variables after which I use them as parameters (why not ExecuteMethod(aquireParameterData());)
         *  Principle of Command Query Separation:
         *      A method should either be a command (executes things -> send parameter data) or a query (returns data -> define parameter data) but not both.
         *      
         *  Single Responsability Principle (SRP):
         *  Robert Cecil Martin advice from book Clean Code:
         *      Code should not do too many things at once; Including constructing parameters while inputting parameters.
         */

    /* [NOTE] On declaring, and/then initialising variables after which I use them as parameters (why not ExecuteMethod(aquireParameterData());)
         *  Definition of View and Controller:
         *      The Controller is responsible for routing, business logic, data manipulation, view selection and state management.
         *      The View is responsible for Presentation logic, data binding, user events, rendering and state presentation.
         *      Both can be responsible for setting the title.
         *      Specificly, the View is responsible for HOW the title is shown, not WHAT title is shown.
         *      
         *  Dependency Inversion Principle:
         *      The Business rule and logic shouldn't be duplicated and imbued into every View instance.
         *      Whenever the Business rule and logic changes manually or at runtime, this tight will coupling causes problems.
         *          
         *      
         *  Single Responsability Principle (SRP):
         *  Robert Cecil Martin advice from book Clean Code:
         *      Code should not do too many things at once; Including constructing parameters while inputting parameters.
         */
}
