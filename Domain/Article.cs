namespace Domain
{
    public class Article
    {
        public int Id { get; set; }
        public int AuthorId { get; set;}
        public Author Author { get; set; } = new(string.Empty);
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Likes { get; set; }

        public List<Comment> Comments { get; set; } = new();

        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        protected Article()
        {
                
        }

        public Article(string tittle, string text)
        {
            Title = tittle;
            Text = text;
            CreationTime = DateTime.Now;
        }
    }
}
