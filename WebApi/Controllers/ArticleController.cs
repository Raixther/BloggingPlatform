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
        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetArticlesByAuthor(string authorName)
        {

            IEnumerable<Article> result = _dbContext.Articles.Where(article => article.AuthorId == _dbContext.Authors.FirstOrDefault(author => author.Name == authorName).Id).AsEnumerable();
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetArticlesByTimeSpan(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult CreateArticle(string text, string title, Author author)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult DeleteArticleById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
