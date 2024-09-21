using BloggingPlatform.Endpoints.CreateArticle.Extensions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BloggingPlatform.Endpoints.CreateArticle
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateArticleController : ControllerBase
    {
        private readonly CreateArticleDbContext _context;
        public CreateArticleController(CreateArticleDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> CreateArticle(ArticleDto articleDto)
        {
           Article article = articleDto.ToArticle();
           await _context.Articles.AddAsync(article);
           _context.SaveChanges();
           return Ok();
        }
        
    }
}
