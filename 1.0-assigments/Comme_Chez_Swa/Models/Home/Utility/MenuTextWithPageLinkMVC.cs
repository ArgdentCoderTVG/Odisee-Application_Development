namespace Comme_Chez_Swa.Models.Home.Utility
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class MenuTextWithPageLinkMVC
    {
        public string FullText { get; }
        public string LinkedText { get; }
        public string LinkedTextPlaceholder { get; }
        public string NameOfActionMVC { get; }
        public string NameOfControllerMVC { get; }

        // [NOTE] One entry point for altering the object state
        public MenuTextWithPageLinkMVC(string fullText, string linkedText, string linkedTextPlaceholder, string nameOfActionMVC, string nameOfControllerMVC)
        {
            FullText = fullText;
            LinkedText = linkedText;
            LinkedTextPlaceholder = linkedTextPlaceholder;
            NameOfActionMVC = nameOfActionMVC;
            NameOfControllerMVC = nameOfControllerMVC;
        }
    }
}