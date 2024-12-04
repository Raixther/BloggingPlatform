using DataAccess;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ArticlesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("Author")]
        public ActionResult<IEnumerable<Article>> GetArticlesByAuthor(string authorName)
        {
            if (string.IsNullOrEmpty(authorName))
            {
                return BadRequest();
            }
            IEnumerable<Article> result = _dbContext.Articles.Where(article => article.AuthorId == _dbContext.Authors.FirstOrDefault(author => author.Name == authorName).Id).AsEnumerable();
            return Ok(result);
        }

        [HttpGet("TimePeriod")]
        public ActionResult<IEnumerable<Article>> GetArticlesByPeriod(DateTime time1, DateTime time2)
        {
            var result = _dbContext.Articles.Where(a => a.CreationTime >= time1 && a.CreationTime <= time2).AsEnumerable();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateArticle(string text, string title, string authorName)
        {

            if (authorName is null || title is null || text is null)
                return BadRequest();
            Article article = new(title, text);
            Author author = new Author(authorName);
            article.Author = author;
            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();
            return Created();
        }
          
        [HttpDelete]
        public ActionResult DeleteArticleByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))          
                return BadRequest();            
            Article article = _dbContext.Articles.FirstOrDefault(article => article.Title == title);
            _dbContext.Articles.Remove(article);
            return Ok();
        }
    }
}
