using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int ArticleId { get; set; }

        List<Author> authors = new List<Author>();

        protected Comment()
        {
                
        }
        public Comment(string text)
        {
            Text = text;
        }
    }
}
