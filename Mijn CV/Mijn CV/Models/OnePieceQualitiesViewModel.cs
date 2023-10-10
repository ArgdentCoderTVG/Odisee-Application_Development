namespace Mijn_CV.Models
{
    public class OnePieceQualitiesModel
    {
        public List<OnePieceQuality> OnePieceQualities { get; private set; }

        public OnePieceQualitiesModel(List<OnePieceQuality> onePieceQualities)
        {
            OnePieceQualities = onePieceQualities;
        }
    }
}
