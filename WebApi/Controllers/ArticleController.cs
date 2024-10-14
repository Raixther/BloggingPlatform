using DataAccess;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ArticleController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("Author")]
        public ActionResult<IEnumerable<Article>> GetArticlesByAuthor(string authorName)
        {

            IEnumerable<Article> result = _dbContext.Articles.Where(article => article.AuthorId == _dbContext.Authors.FirstOrDefault(author => author.Name == authorName).Id).AsEnumerable();
            return Ok(result);
        }

        [HttpGet("TimeSpan")]
        public ActionResult<IEnumerable<Article>> GetArticlesByTimeSpan(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult CreateArticle(string text, string title, string authorName)
        {
            Article article = new(title, text);
           
            if (authorName is null)
                return BadRequest();
            if (!_dbContext.Authors.Contains(_dbContext.Authors.FirstOrDefault(a => a.Name == authorName)))
            {
                Author author = new Author(authorName);
                article.Author = author;
                _dbContext.Articles.Add(article);
                _dbContext.SaveChanges();
                return Ok(article);
            }
            else
            {
                _dbContext.Articles.Add(article);
                _dbContext.SaveChanges();
                return Ok();
            }

        }
          
        [HttpDelete]
        public ActionResult DeleteArticleById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
