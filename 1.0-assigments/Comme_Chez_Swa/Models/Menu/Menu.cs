namespace Comme_Chez_Swa.Models.Menu
{
    public class Menu
    {
        public string Id { get; set; }
        public string Naam { get; set; }
        public IEnumerable<Gerecht> Gerechten { get; set; }
    }
}
