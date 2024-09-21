namespace BloggingPlatform.Endpoints.CreateArticle.Extensions
{
    public static class ArticleDtoExtensions
    {
        public static Article ToArticle(this ArticleDto articleDto)
        {
            return new Article() 
            { Author = articleDto.Author, Title = articleDto.Title, Text = articleDto.Text };
        }
    }
}
