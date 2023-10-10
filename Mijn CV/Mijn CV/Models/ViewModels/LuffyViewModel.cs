using Mijn_CV.Models.DataModels;

namespace Mijn_CV.Models.ViewModels
{
    public class LuffyViewModel
    {
        public OnePieceCharacter? OnePieceCharacter { get; private set; }

        public LuffyViewModel(OnePieceCharacter onePieceCharacter)
        {
            OnePieceCharacter = onePieceCharacter;
        }
    }
}
