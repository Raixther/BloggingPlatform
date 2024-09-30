namespace Domain
{
    public class Article
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Likes { get; set; }

        public DateTime CreationTime { get; set; }

        protected Article()
        {
                
        }

        public List<Comment> Comments { get; set; } = new();
        public Article(string tittle, string text)
        {
            Title = tittle;
            Text = text;
            CreationTime = DateTime.Now;
        }
    }
}
