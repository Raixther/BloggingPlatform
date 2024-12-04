using DataAccess;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CommentsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public ActionResult CreateComment(string commentText, string authorName, int articleId)
        {
            if (string.IsNullOrEmpty(authorName)|| string.IsNullOrEmpty(commentText))
            {
                return BadRequest();
            }
            Comment comment = new Comment(commentText, authorName);
            _dbContext.Comments.Add(comment);
            Article article = _dbContext.Articles.FirstOrDefault(a => a.Id == articleId);
            article.Comments.Add(comment);
            _dbContext.SaveChanges();
            return Ok();
        }
       
    }
}
