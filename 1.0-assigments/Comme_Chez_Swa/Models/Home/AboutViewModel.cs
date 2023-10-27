namespace Comme_Chez_Swa.Models.Home
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class AboutViewModel : BaseViewModel
    {
        public string AboutUsHeadingText { get; }
        public string AboutUsContentText { get; }

        // [NOTE] One entry point for altering the object state
        public AboutViewModel(string aboutUsHeadingText, string aboutUsContentText)
        {
            AboutUsHeadingText = aboutUsHeadingText;
            AboutUsContentText = aboutUsContentText;
        }
    }
}
