using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().Property<DateTime>(a=>a.CreationTime).HasColumnType("date");           
            
            modelBuilder.Entity<Article>().HasOne(a=>a.Author).WithMany(a=>a.Articles).HasForeignKey(a=>a.AuthorId);
            modelBuilder.Entity<Comment>().HasOne(a => a.Article).WithMany(a => a.Comments).HasForeignKey(a => a.ArticleId);

        }
    }
}
