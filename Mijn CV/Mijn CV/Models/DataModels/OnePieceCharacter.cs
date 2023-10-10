namespace Mijn_CV.Models.DataModels
{
    public class OnePieceCharacter
    {
        public string Name { get; private set; }
        public string Epithet { get; private set; }
        public string Crew { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public string WikiUrl { get; private set; }

        public OnePieceCharacter(string name = "", string epithet = "", string crew = "", DateTime? birthDate = null, string description = "", string imageUrl = "", string wikiUrl = "")
        {
            Name = name;
            Epithet = epithet;
            Crew = crew;
            BirthDate = birthDate ?? DateTime.MinValue; // No null value that breaks DateTime operations
            Description = description;
            ImageUrl = imageUrl;
            WikiUrl = wikiUrl;
        }
    }
}
