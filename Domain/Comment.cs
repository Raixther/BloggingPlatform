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
        public Article Article { get; set; }
        public Author Author { get; init; }
        protected Comment()
        {
                
        }
        public Comment(string text, string authorName)
        {
            Text = text;
            Author = new(authorName);
          
        }
    }
}
