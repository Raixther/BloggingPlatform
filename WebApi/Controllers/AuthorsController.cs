using DataAccess;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public AuthorsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]

        public ActionResult CreateAuthor(string authorName)
        {
            if (string.IsNullOrEmpty(authorName))
            {
                return BadRequest();
            }
            if (_dbContext.Authors.Where(a => a.Name == authorName) is not null)
            {
                Author author = new(authorName);
                _dbContext.Authors.AddAsync(author);
            }
            return Ok();
        }


        [HttpDelete]
        public ActionResult DeleteByName(string authorName)
        {
            if (string.IsNullOrEmpty(authorName))
            {
                return BadRequest();
            }

            Author author = _dbContext.Authors.FirstOrDefault(a => a.Name == authorName);
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
