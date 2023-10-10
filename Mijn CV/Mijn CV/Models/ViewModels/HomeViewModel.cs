using Mijn_CV.Models.DataModels;

namespace Mijn_CV.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<OnePieceQuality> OnePieceQualities { get; private set; }
        public List<OnePieceCharacter> OnePieceCharacters { get; private set; }
        public OnePieceDevilFruit OnePieceDevilFruit { get; private set; }

        public HomeViewModel(List<OnePieceQuality> onePieceQualities, List<OnePieceCharacter> onePieceCharacters, OnePieceDevilFruit devilfruit)
        {
            OnePieceQualities = onePieceQualities;
            OnePieceCharacters = onePieceCharacters;
            OnePieceDevilFruit = devilfruit;
        }
    }
}
