namespace Demo_Entity_Framework.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Inhoud { get; set; }
        public DateTime PublicatieDatum { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
