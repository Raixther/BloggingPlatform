using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public List<Article> Articles { get; set; } = new();

        public List<Comment> comments { get; set; } = new();

        protected Author()
        {
                
        }
        public Author(string name)
        {
             Name = name;
        }


    }
}
