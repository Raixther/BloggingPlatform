using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace BloggingPlatform.Endpoints.ReadArticle
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadArticleController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> ReadArticle(int id)
        {
            using (SqliteConnection connection = new(connectionString: "Data Source = MyDb.db;"))
            {
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM articles WHERE id = {id}";//
                DbDataReader reader = command.ExecuteReader();

                object o = reader.GetValue(2);
                return Ok(o);
            }                       
        }        
    }
}
