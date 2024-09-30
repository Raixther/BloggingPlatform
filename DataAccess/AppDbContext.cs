using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Author> Authors { get; set; }  
       public DbSet<Article> Articles { get; set; }
       public DbSet<Comment> Comments { get; set; }

    }
}
