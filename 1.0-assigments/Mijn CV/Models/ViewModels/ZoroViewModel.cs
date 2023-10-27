using Mijn_CV.Models.DataModels;

namespace Mijn_CV.Models.ViewModels
{
    public class ZoroViewModel
    {
        public OnePieceCharacter? OnePieceCharacter { get; private set; }

        public ZoroViewModel(OnePieceCharacter onePieceCharacter)
        {
            OnePieceCharacter = onePieceCharacter;
        }
    }
}
