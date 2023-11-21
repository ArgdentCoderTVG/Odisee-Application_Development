namespace Demo_Entity_Framework.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Inhoud { get; set; }
        public string Auteur { get; set; }
        public DateTime Tijdstip { get; set; }
    }
}
