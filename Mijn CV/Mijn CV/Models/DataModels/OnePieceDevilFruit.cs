namespace Mijn_CV.Models.DataModels
{
    public class OnePieceDevilFruit
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public string WikiUrl { get; private set; }

        public OnePieceDevilFruit(string name = "", string description = "", string imageUrl = "", string wikiUrl = "")
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            WikiUrl = wikiUrl;
        }
    }
}
