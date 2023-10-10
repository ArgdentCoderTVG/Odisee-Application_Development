namespace Mijn_CV.Models
{
    public class OnePieceQuality
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public string ExploratoryLink { get; private set; }

        public OnePieceQuality(string name = "", string description = "", string imageUrl = "", string exploratoryLink = "")
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            ExploratoryLink = exploratoryLink;
        }
    }
}
