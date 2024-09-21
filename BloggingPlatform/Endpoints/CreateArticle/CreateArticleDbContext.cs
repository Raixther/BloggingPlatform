using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Endpoints.CreateArticle
{
    public class CreateArticleDbContext : DbContext
    {
        public DbSet<Article> Articles {  get; set; }
        public CreateArticleDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
