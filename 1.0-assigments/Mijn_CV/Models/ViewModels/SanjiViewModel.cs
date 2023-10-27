using Mijn_CV.Models.DataModels;

namespace Mijn_CV.Models.ViewModels
{
    public class SanjiViewModel
    {
        public OnePieceCharacter? OnePieceCharacter { get; private set; }

        public SanjiViewModel(OnePieceCharacter onePieceCharacter)
        {
            OnePieceCharacter = onePieceCharacter;
        }
    }
}
