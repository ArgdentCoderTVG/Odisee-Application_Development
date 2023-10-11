using Mijn_CV.Models.DataModels;

namespace Mijn_CV.Models.ViewModels
{
    public class DevilFruitViewModel
    {
        public OnePieceDevilFruit OnePieceDevilFruit { get; private set; }

        public DevilFruitViewModel(OnePieceDevilFruit devilfruit)
        {
            OnePieceDevilFruit = devilfruit;
        }
    }
}
