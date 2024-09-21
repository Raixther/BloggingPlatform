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
                command.CommandText = @"SELECT *
                FROM Articles
                WHERE id = $id";

                command.Parameters.Add(id);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var o = reader.GetValue(0);
                        Console.WriteLine(o);
                    }
                }
                
                return Ok();
            }                       
        }        
    }
}
